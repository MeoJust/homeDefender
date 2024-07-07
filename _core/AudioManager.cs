using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public float MusicVolume = 0.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
}
