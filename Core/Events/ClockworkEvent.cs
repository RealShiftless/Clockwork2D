using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D.Events
{
    public sealed class ClockworkEvent
    {
        /* EVENT VARIABLES */
        private Event _event;


        /* FUNC */
        public void Invoke()
        {
            _event.Invoke();
        }
        public void TryInvoke()
        {
            _event?.Invoke();
        }


        /* DELEGATE */
        public delegate void Event();


        /* OVERRIDES */
        public override bool Equals(object obj)
        {
            if(_event == null && obj == null)
                return true;

            return base.Equals(obj);
        }


        /* OPERATOR OVERLOADS */
        public static ClockworkEvent operator +(ClockworkEvent self, Event other)
        {
            self._event += other;

            return self;
        }
        public static ClockworkEvent operator -(ClockworkEvent self, Event other)
        {
            self._event -= other;

            return self;
        }
    }
}
