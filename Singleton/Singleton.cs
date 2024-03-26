using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance == null)
                {
                    //Warning when there isn't instance
                    Debug.LogWarning("Instance of " +  typeof(T).FullName + " was not found. Created one");

                    //If there isn't instance, create one
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        //If there is more than 1 instance, destroy this
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this as T;

        //Uncomment the line below for DontDestroyOnLoad
        //DontDestroyOnLoad(instance);
    }

    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
