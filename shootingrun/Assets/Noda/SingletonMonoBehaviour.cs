using UnityEngine;

namespace Singleton
{
    /// <summary>
    /// シングルトン基底クラス(MonoBehaviour継承)
    /// </summary>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if ((instance == null))
                    {
                        Debug.LogWarning(typeof(T) + "is nothing");
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (this.CheckInstance())
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }

        bool CheckInstance()
        {
            if (instance == null)
            {
                instance = (T)this;
                return true;
            }
            else if (Instance == this)
            {
                return true;
            }
            Destroy(this.gameObject);
            return false;
        }
    }
}