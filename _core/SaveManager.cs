using UnityEngine;
using YG;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
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

    void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    public void GetLoad()
    {
        if (MoneyManager.Instance)
        {
            MoneyManager.Instance.TotalMoney = YandexGame.savesData.Money;
            // print("money loaded: " + MoneyManager.Instance.TotalMoney);
        }

        if (GunManager.Instance)
        {
            GunManager.Instance.BuyedGunz = YandexGame.savesData.GunIds;
            // print("guns loaded");
        }

        GameManager.Instance.Wave = YandexGame.savesData.Level;
    }

    public void Save()
    {
        if (MoneyManager.Instance)
        {
            YandexGame.savesData.Money = MoneyManager.Instance.TotalMoney;
            YandexGame.SaveProgress();
        }

        if (GunManager.Instance)
        {
            YandexGame.savesData.GunIds = GunManager.Instance.BuyedGunz;
            YandexGame.SaveProgress();
        }

        YandexGame.savesData.Level = GameManager.Instance.Wave;
    }
}
