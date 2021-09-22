using UnityEngine;

namespace Framework.Extension
{
    public class SingletonDestroyable<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected virtual void Awake()
        {
            SingletonFunction();
        }

        private void SingletonFunction()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
			else if (Instance == null)
			{
                Instance = FindObjectOfType<T>();
			}
        }
    }
}