using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public class GameObject : EngineComponent
    {
        /* REFERENCES */
        private ObjectManager _objectManager;


        /* GAME OBJECTS VARIABLES */
        public string Name;
        public bool IsActive
        {
            get
            {
                return _active;
            }

            set
            {
                _objectManager.CheckObjectActivity(this);
            }
        }
        private bool _active = true;

        public Vector2 Position;


        /* COMPONENTS */
        private Dictionary<Type, Component> _componentDict = new Dictionary<Type, Component>();
        private List<Component> _components = new List<Component>();
        private List<Component> _activeComponents = new List<Component>();


        /* CONSTRUCTOR */
        public GameObject(ObjectManager objectManager, string name)
        {
            _objectManager = objectManager;

            Name = name;
        }


        /* MAIN */
        public void Update(GameTime time)
        {
            foreach(Component component in _activeComponents)
            {
                component.Update(time);
            }
        }
        public void Draw(GameTime time)
        {
            foreach (Component component in _activeComponents)
            {
                component.Draw(time);
            }
        }


        /* FUNC */
        public T AddComponent<T>(params object[] parameters) where T : Component, new()
        {
            // Error catching
            if(_componentDict.ContainsKey(typeof(T)))
                throw new Exception("Component of type " + typeof(T) + " was already registered in game object " + Name + "!");

            // intialzing component
            T component = new T();
            component.DoInit(this, parameters);

            // Adding component to game object
            _componentDict.Add(typeof(T), component);
            _components.Add(component);

            // Adding the component to the active pool if it is active after initialize
            if(component.IsActive)
                _activeComponents.Add(component);

            return component;
        }
        public T GetComponent<T>() where T : Component
        {
            if(!_componentDict.ContainsKey(typeof(T)))
                throw new Exception("Game Object " + Name + " does not contain Component " + typeof(T).Name);

            return (T)_componentDict[typeof(T)];
        }
        public void RemoveComponent<T>() where T : Component
        {
            if (!_componentDict.ContainsKey(typeof(T)))
                throw new Exception("Game Object " + Name + " does not contain Component " + typeof(T).Name);

            Component component = _componentDict[typeof(T)];

            _componentDict.Remove(typeof(T));
            _components.Remove(component);
            _activeComponents.Remove(component);
        }
        public void CheckComponentActivity(Component component)
        {
            if(component.IsActive)
            {
                if(!_activeComponents.Contains(component))
                    _activeComponents.Add(component);
            }
            else
            {
                if(_activeComponents.Contains(component))
                    _activeComponents.Remove(component);
            }
        }

    }
}
