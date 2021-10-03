using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public static class Extensions
    {
        public static Vector2 ToCameraSpace(this Vector2 worldSpace)
        {
            return worldSpace - Camera.Main.Position + ClockworkGame2D.Instance.GetWindowSize()/2;
        }

        public static Vector2 ToWorldSpace(this Vector2 camSpace)
        {
            return camSpace + Camera.Main.Position - ClockworkGame2D.Instance.GetWindowSize() / 2;
        }
    }
}
