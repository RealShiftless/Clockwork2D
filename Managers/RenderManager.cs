using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D.Internal
{
    public static class RenderManager
    {
        /* REFERENCES */
        private static SpriteBatch _spriteBatch;


        /* CAMERA MANAGING */
        public static Camera ActiveCamera { get; private set; }


        /* STANDARD EFFECT */
        private static SpriteEffect _standardEffect;


        /* RENDER MANAGING */
        public static SpriteBatchSettings SpriteBatchSettings;
        private static bool _isStarted = false;
        private static Dictionary<Effect, List<RenderCall>> _requests;


        /* MAIN */
        public static void Initialize(SpriteBatch spriteBatch, SpriteEffect standardEffect)
        {
            if(_spriteBatch != null)
                throw new Exception("Render Manager was already initialized!");

            _spriteBatch = spriteBatch;

            _standardEffect = standardEffect;
        }
        public static void Begin(Camera camera)
        {
            if(_isStarted)
                throw new Exception("RenderManager was already started!");

            _requests = new Dictionary<Effect, List<RenderCall>>();

            ActiveCamera = camera;

            _isStarted = true;
        }
        public static void End()
        {
            if(!_isStarted)
                throw new Exception("RenderManager was not started, so can not be ended!");

            foreach(KeyValuePair<Effect, List<RenderCall>> keyValuePair in _requests)
            {
                _spriteBatch.Begin(SpriteBatchSettings.SortMode, SpriteBatchSettings.BlendState, SpriteBatchSettings.SamplerState, SpriteBatchSettings.DepthStencilState, SpriteBatchSettings.RasterizerState, keyValuePair.Key, SpriteBatchSettings.TransformMatrix);
                
                foreach(RenderCall renderCall in keyValuePair.Value)
                {
                    renderCall.Item.Draw(_spriteBatch, ActiveCamera, renderCall.DestinationRectangle, renderCall.Rotation);
                }

                _spriteBatch.End();
            }

            ActiveCamera = null;

            _isStarted = false;
        }


        public static void BeginBatch(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null)
        {
            _spriteBatch.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
        }
        public static void EndBatch()
        {
            _spriteBatch.End();
        }



        /* FUNC */
        public static void DrawSprite(Sprite sprite, Vector2 position, float rotation = 0)
        {
            if (!_isStarted)
                throw new Exception("Cannot draw a sprite outside of main draw loop!");

            Effect effect = (sprite.Effect == null) ? _standardEffect : sprite.Effect;

            if (!_requests.ContainsKey(effect))
                _requests.Add(effect, new List<RenderCall>());

            _requests[effect].Add(new RenderCall(sprite, new Rectangle((int)position.X, (int)position.Y, (int)sprite.Width, (int)sprite.Height), 0));
        }


        /* DELEGATES */


        /* RENDER CALL STRUCT */
        private struct RenderCall
        {
            public IDrawable Item;
            public Rectangle DestinationRectangle;
            public float Rotation;

            public RenderCall(IDrawable item, Rectangle destinationRectangle, float rotation)
            {
                Item = item;
                DestinationRectangle = destinationRectangle;
                Rotation = rotation;
            }
        }
    }
}
