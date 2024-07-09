using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int TotalMoney = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Invoke(nameof(LoadMoney), .25f);
    }

    void LoadMoney()
    {
        SaveManager.Instance.GetLoad();
    }
}
