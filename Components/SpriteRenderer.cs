using Microsoft.Xna.Framework;

namespace Clockwork2D
{
    class SpriteRenderer : Component, IClickable
    {
        public Sprite Sprite;
        public OnClickCallback Clicked
        {
            get
            {
                return _onClicked;
            }

            set
            {
                if(_onClicked != value)
                {
                    if(value != null)
                    {
                        Input.RegisterClickable(this);
                    }
                    else
                    {
                        Input.UnregisterClickable(this);
                    }
                }

                _onClicked = value;
            }
        }

        private OnClickCallback _onClicked;

        protected override void Initialize(object[] paramaters)
        {
            Sprite = (Sprite) paramaters[0];
        }

        public override void Draw(GameTime time)
        {
            DrawSprite(Sprite, GameObject.Position);
        }

        public Rectangle GetBody()
        {
            Vector2 cameraSpacePosition = new Vector2(GameObject.Position.X, GameObject.Position.Y).ToCameraSpace();

            return new Rectangle((int)cameraSpacePosition.X, (int)cameraSpacePosition.Y, (int)Sprite.Width, (int)Sprite.Height);
        }

        public void OnClick()
        {
            _onClicked?.Invoke();
        }

        public delegate void OnClickCallback();
    }
}
