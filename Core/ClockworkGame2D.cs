using Clockwork2D.Internal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public abstract class ClockworkGame2D : EngineComponent, IDisposable
    {
        /* SINGLETON */
        public static ClockworkGame2D Instance { get; private set; }


        /* ENGINE COMPONENTS */
        private GameContainer _container;


        /* WINDOWS SETTINGS */
        public bool IsMouseVisible
        {
            get
            {
                return _container.IsMouseVisible;
            }

            set
            {
                _container.IsMouseVisible = value;
            }
        }
        


        // Constructor
        public ClockworkGame2D()
        {
            if(Instance != null)
                throw new Exception("Cannot intantiate more than 1 Clockwork2DGame");

            Instance = this;

            _container = new GameContainer();

            _container.Initializing += Initialize;
        }


        /* MAIN */
        public void Run()
        {
            _container.Run();
        }


        /* FUNC */
        public void SetWindowSize(int width, int height)
        {
            _container.Graphics.PreferredBackBufferWidth = width;
            _container.Graphics.PreferredBackBufferHeight = height;
            _container.Graphics.ApplyChanges();
        }


        /* GETTERS */
        public GraphicsDevice GetGraphicsDevice()
        {
            return _container.GraphicsDevice;
        }
        public GraphicsDeviceManager GetGraphicsDeviceManager()
        {
            return _container.Graphics;
        }
        public ContentManager GetContentManager()
        {
            return _container.Content;
        }
        public Vector2 GetWindowSize()
        {
            return new Vector2(WindowWidth, WindowHeight);
        }


        /* VIRTUALS */
        protected abstract void Initialize();


        /* INTERFACE */
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
