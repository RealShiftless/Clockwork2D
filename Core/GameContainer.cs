using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Clockwork2D.Internal
{
    public class GameContainer : Game
    {
        /* MONOGAME STUFF */
        public GraphicsDeviceManager Graphics;
        private SpriteBatch _spriteBatch;


        /* CLOCKWORK CALLBACKS */
        public MonogameCallback Initializing;


        /* CONSTRUCTOR */
        public GameContainer()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        /* MAIN */
        protected override void Initialize()
        {
            Initializing?.Invoke();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            RenderManager.Initialize(_spriteBatch, new SpriteEffect(GraphicsDevice));
            SceneManager.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }


        /* DELEGATES */
        public delegate void MonogameCallback();
    }
}
