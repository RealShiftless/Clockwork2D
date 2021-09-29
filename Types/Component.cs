using Clockwork2D.Internal;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public abstract class Component : EngineComponent
    {
        public bool IsActive
        {
            get
            {
                return _active;
            }

            set
            {
                if(GameObject == null)
                    throw new Exception("Cannot set activity of Component with no GameObject");

                if(_active != value)
                {
                    _active = value;
                    GameObject.CheckComponentActivity(this);
                }
            }
        }

        private bool _active = true;

        public GameObject GameObject { get; private set; }


        public void DoInit(GameObject gameObject, object[] parameters)
        {
            GameObject = gameObject;

            Initialize(parameters);
        }



        protected virtual void Initialize(object[] paramaters) { }
        public virtual void Update(GameTime time) { }
        public virtual void Draw(GameTime time) { }


        /* FUNC */
        protected void DrawSprite(Sprite sprite, Vector2 position, float rotation = 0)
        {
            RenderManager.DrawSprite(sprite, position, rotation);
        }
    }
}
