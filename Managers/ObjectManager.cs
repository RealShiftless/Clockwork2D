using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public class ObjectManager : EngineComponent
    {
        /* OBJECT MANAGEMENT */
        private Dictionary<string, GameObject> _gameObjectDict = new Dictionary<string, GameObject>();
        private List<GameObject> _gameObjects = new List<GameObject>();
        private List<GameObject> _activeGameObject = new List<GameObject>();


        /* MAIN */
        public void Update(GameTime time)
        {
            foreach (GameObject gameObject in _activeGameObject)
            {
                gameObject.Update(time);
            }
        }
        public void Draw(GameTime time)
        {
            foreach (GameObject gameObject in _activeGameObject)
            {
                gameObject.Draw(time);
            }
        }


        /* FUNC */
        public GameObject CreateGameObject(string name)
        {
            GameObject obj = new GameObject(this, name);

            RegisterGameObject(obj);

            return obj;
        }
        public void RegisterGameObject(GameObject obj)
        {
            if (_gameObjectDict.ContainsKey(obj.Name))
                throw new Exception("Object with name " + obj.Name + " was already registered in scene of type " + GetType().Name);

            _gameObjectDict.Add(obj.Name, obj);
            _gameObjects.Add(obj);
            _activeGameObject.Add(obj);
        }
        public void CheckObjectActivity(GameObject obj)
        {
            if(obj.IsActive)
            {
                if(!_activeGameObject.Contains(obj))
                    _activeGameObject.Add(obj);
            }
            else
            {
                if(_activeGameObject.Contains(obj))
                    _activeGameObject.Remove(obj);
            }
        }
    }
}
