using Clockwork2D.Internal;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public class Scene : EngineComponent
    {
        /* OBJECT STUFF */
        private ObjectManager _objectManager;


        /* CAMERA STUFF */
        public List<Camera> Cameras = new List<Camera>();


        /* MAIN */
        public void DoInit()
        {
            _objectManager = new ObjectManager();

            Cameras.Add(new Camera(Vector2.Zero));

            Awake();
            LoadContent();
            Start();

            if(Cameras.Count == 0)
                throw new Exception("No camera was attatched to scene");
        }
        public void Update(GameTime time)
        {
            _objectManager.Update(time);
        }
        public void Draw(GameTime time)
        {
            foreach (Camera camera in Cameras)
            {
                if(camera.ClearColor != Color.Transparent)
                    GraphicsDevice.Clear(camera.ClearColor);

                RenderManager.Begin(camera);

                _objectManager.Draw(time);

                RenderManager.End();
            }
        }
        public void DoClosing()
        {

        }


        /* FUNC */
        public GameObject CreateGameObject(string name)
        {
            return _objectManager.CreateGameObject(name);
        }


        /* VIRTUALS */
        protected virtual void Awake() { }
        protected virtual void LoadContent() { }
        protected virtual void Start() { }
        protected virtual void Closing() { }
    }
}
