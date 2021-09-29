using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Clockwork2D
{
    public class EngineComponent
    {
        protected GraphicsDevice GraphicsDevice
        {
            get
            {
                return ClockworkGame2D.Instance.GetGraphicsDevice();
            }
        }
        protected GraphicsDeviceManager Graphics
        {
            get
            {
                return ClockworkGame2D.Instance.GetGraphicsDeviceManager();
            }
        }
        protected ContentManager Content
        {
            get
            {
                return ClockworkGame2D.Instance.GetContentManager();
            }
        }
        protected int WindowWidth
        {
            get
            {
                return Graphics.PreferredBackBufferWidth;
            }
        }
        protected int WindowHeight
        {
            get
            {
                return  Graphics.PreferredBackBufferHeight;
            }
        }


        protected void print(object message)
        {
            Debug.WriteLine(message);
        }
    }
}
