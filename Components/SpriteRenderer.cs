using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    class SpriteRenderer : Component
    {
        public Sprite Sprite;

        protected override void Initialize(object[] paramaters)
        {
            Sprite = (Sprite) paramaters[0];
        }

        public override void Draw(GameTime time)
        {
            DrawSprite(Sprite, GameObject.Position);
        }
    }
}
