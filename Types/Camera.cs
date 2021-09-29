using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public sealed class Camera : EngineComponent
    {
        /* CAMERA VARIABLES */
        public Vector2 Position;
        public RenderTarget2D Target;
        public Color ClearColor = new Color(31, 31, 31);


        /* CONSTRUCTOR */
        public Camera(Vector2 position)
        {
            Position = position;
        }
    }
}
