using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public interface IClickable
    {
        public Rectangle GetBody();
        public void OnClick();
    }


}
