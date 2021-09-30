using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public class Sprite : EngineComponent, IDrawable
    {
        public Texture2D Texture;
        public Rectangle? SourceRectangle;
        public Color Color;
        public Vector2 Origin;
        public Vector2 Scale;

        private SpriteEffects _spriteFlip
        {
            get
            {
                return ((FlipX ? SpriteEffects.FlipHorizontally : 0) | (FlipY ? SpriteEffects.FlipVertically : 0));
            }
        }

        public bool FlipX = false;
        public bool FlipY = false;

        public float LayerDepth;

        public Effect Effect;

        /// <summary>
        /// The Width times the scale of the sprite
        /// </summary>
        public float Width
        {
            get
            {
                return Texture.Width * Scale.X;
            }
        }
        /// <summary>
        /// The Height times the scale of the sprite
        /// </summary>
        public float Height
        {
            get
            {
                return Texture.Height * Scale.Y;
            }
        }
        /// <summary>
        /// The raw Width of the sprite
        /// </summary>
        public int RawWidth
        {
            get
            {
                return Texture.Width;
            }
        }
        /// <summary>
        /// The raw Height of the sprite
        /// </summary>
        public int RawHeight
        {
            get
            {
                return Texture.Height;
            }
        }

        public Sprite(Texture2D texture)
        {
            Texture = texture;

            Color = Color.White;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
        }

        public void Draw(SpriteBatch spriteBatch, Camera fromCamera, Rectangle destinationRect, float rotation)
        {
            Rectangle cameraPerspectiveRect = new Rectangle(
                    (int)(WindowWidth  / 2 + ( destinationRect.X - fromCamera.Position.X )),
                    (int)(WindowHeight / 2 + ( destinationRect.Y - fromCamera.Position.Y )),
                    destinationRect.Width,
                    destinationRect.Height
                );

            spriteBatch.Draw(Texture, cameraPerspectiveRect, SourceRectangle, Color, rotation, Origin, _spriteFlip, LayerDepth);
        }
    }
}
