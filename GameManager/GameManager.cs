using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //Sample
    //public AudioManager AudioManager {get; private set}

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.LogError("There is more than one " +  Instance.name);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance.gameObject);

        //Sample
        //AudioManager = GetComponentInChildren<AudioManager>().;
    }
}
