using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public interface IDrawable
    {
        public void Draw(SpriteBatch spriteBatch, Camera fromCamera, Rectangle destinationRect, float rotation);
    }
}
