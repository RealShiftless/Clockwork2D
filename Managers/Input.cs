using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Clockwork2D
{
    public static class Input
    {
        private static List<IClickable> _clickables = new List<IClickable>();

        public static MouseState Mouse = new MouseState();


        // Main
        public static void Initialize()
        {
            SceneManager.ClosingScene += (s) => 
            { 
                _clickables.Clear(); 
                Debug.WriteLine("Clearing them clickables boy!");
            };
        }
        public static void Update()
        {
            DoMouse();

            if(Mouse.Left == ButtonState.Pressed)
                DoClickables();
        }
        private static void DoMouse()
        {
            Microsoft.Xna.Framework.Input.MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();

            if(Mouse.Left == ButtonState.None || Mouse.Left == ButtonState.Released)
                Mouse.Left = (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) ? ButtonState.Pressed : ButtonState.None;
            else
                Mouse.Left = (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) ? ButtonState.Held : ButtonState.Released;

            Mouse.X = mouseState.X;
            Mouse.Y = mouseState.Y;
        }
        private static void DoClickables()
        {
            foreach (IClickable clickable in _clickables)
            {
                if(clickable.GetBody().Contains(Mouse.Position))
                {
                    clickable.OnClick();
                }
            }
        }

        public static void RegisterClickable(IClickable clickable)
        {
            _clickables.Add(clickable);
        }
        public static void UnregisterClickable(IClickable clickable)
        {
            _clickables.Remove(clickable);
        }
        

        // Classes
        public class MouseState
        {
            public ButtonState Left;
            public ButtonState Middle;
            public ButtonState Right;

            public Vector2 Position
            {
                get
                {
                    return new Vector2(X,Y);
                }
            }
            public int X, Y;
        }
    }

    public enum ButtonState
    {
        None = 0,
        Pressed,
        Held,
        Released
    }
}
