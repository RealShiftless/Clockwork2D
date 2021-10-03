using Clockwork2D.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork2D
{
    public static class SceneManager
    {
        /* SCENE VARIABLES */
        private static List<Type> _scenes = new List<Type>();
        private static Dictionary<string, int> _sceneDict = new Dictionary<string, int>();
        private static Scene _currentScene;


        /* EVENTS */
        public static SceneManagerEvent StartingScene;
        public static SceneManagerEvent ClosingScene;



        /* PROPERTIES */
        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
        }


        /* MAIN */
        public static void Initialize()
        {
            if(_currentScene == null)
            {
                if(_scenes.Count == 0)
                    throw new Exception("No scene was registered in initialize!");

                SetScene(0);
            }
        }
        public static void Update(GameTime time)
        {
            _currentScene.Update(time);
        }
        public static void Draw(GameTime time)
        {
            _currentScene.Draw(time);
        }


        /* FUNC */
        public static void RegisterScene<T>(string name) where T : Scene
        {
            if(_sceneDict.ContainsKey(name))
                throw new Exception("A scene with name " + name + " has already been registered!");

            if(_scenes.Contains(typeof(T)))
                throw new Exception("A scene with type " + typeof(T).Name + " has already been registered!");

            _sceneDict.Add(name, _scenes.Count);
            _scenes.Add(typeof(T));
        }
        public static void SetScene(int id)
        {
            if(id >= _scenes.Count)
                throw new Exception("Scene ID: " + id + " is out of range!");

            if(_currentScene != null)
            {
                ClosingScene?.TryInvoke(_currentScene);
                _currentScene.DoClosing();
            }

            _currentScene = (Scene) Activator.CreateInstance(_scenes[id]);
            StartingScene?.TryInvoke(_currentScene);
            _currentScene.DoInit();
        }
        public static void SetScene(string name)
        {
            if(!_sceneDict.ContainsKey(name))
                throw new Exception("Scene of name " + name + " was never registered!");

            SetScene(_sceneDict[name]);
        }
    }
}
