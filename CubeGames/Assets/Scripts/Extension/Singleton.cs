using UnityEngine;

namespace Framework.Extension
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected virtual void Awake()
        {
            SingletonFunction();
        }

        private void SingletonFunction()
        {
            if (Instance == null)
			{
                Instance = FindObjectOfType<T>();
                DontDestroyOnLoad(gameObject);
			}
            else if (Instance != null)
            {
                Debug.Log("Destroyed duplicate singleton! " + this);
                Destroy(gameObject);
            }
        }
    }
}