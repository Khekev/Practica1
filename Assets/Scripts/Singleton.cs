using UnityEngine;

namespace Interfaces.Utils
{ 
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;
        private static readonly object _lock = new object();
        private static bool _willBeDestroyed;

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if(!_instance && !_willBeDestroyed)
                    {
                        GameObject gameObject = new GameObject(typeof(T).ToString(), typeof(T));
                        gameObject.TryGetComponent(out _instance);
                        Instantiate(gameObject);
                    }
                }
                return _instance;
            }
        }

        public static T GetInstance()
        {
            return Instance;
        }

        protected virtual void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = (T)this;
            }
        }

        private void OnApplicationQuit()
        {
            _willBeDestroyed = true;
        }

    }
}
