using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    protected virtual bool ShouldOverride => false;
    protected virtual bool DestroyOnLoad => true;

    public static T Instance { get; private set; }
    public static bool HasInstance => Instance != null;


    protected virtual void Awake()
    {
        if (Instance != null)
        {
            if (ShouldOverride)
            {
                Destroy(Instance.gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        Instance = this as T;

        if (!DestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }

}
