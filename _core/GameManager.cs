using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float Level = 1f;
    public float HouseHealthMultiplier = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
