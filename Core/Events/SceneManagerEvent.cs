using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D.Events
{
    public sealed class SceneManagerEvent
    {
        /* EVENT VARIABLES */
        private Event _event;


        /* FUNC */
        public void Invoke(Scene scene)
        {
            _event.Invoke(scene);
        }
        public void TryInvoke(Scene scene)
        {
            _event?.Invoke(scene);
        }


        /* DELEGATE */
        public delegate void Event(Scene scene);


        /* OVERRIDES */
        public override bool Equals(object obj)
        {
            if (_event == null && obj == null)
                return true;

            return base.Equals(obj);
        }


        /* OPERATOR OVERLOADS */
        public static SceneManagerEvent operator +(SceneManagerEvent self, Event other)
        {
            self._event += other;

            return self;
        }
        public static SceneManagerEvent operator -(SceneManagerEvent self, Event other)
        {
            self._event -= other;

            return self;
        }
    }
}
