using GamePush;
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
        Invoke(nameof(LoadMoney), .1f);

    }

    void LoadMoney(){
        GP_Player.Load();
        TotalMoney = GP_Player.GetInt("money");
        FindObjectOfType<SetupManager>().UpdateMoneyTXT();
    }
}
