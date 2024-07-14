using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GamePush;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int _levelTime = 69;
    [SerializeField] TextMeshProUGUI _levelTimerTXT;
    [SerializeField] TextMeshProUGUI _levelMoooneyTXT;
    [SerializeField] TextMeshProUGUI _waveNumTXT;
    [SerializeField] GameObject _winCNV;
    [SerializeField] Button _doubleRewardBTN;
    [SerializeField] Button _menuBTN;

    public int ZumbyOnLevel = 10;
    int _levelMoooney = 0;

    int _lastRewardedVideoId = -1;

    void OnEnable()
    {
        GP_Ads.OnRewardedReward += OnRewardShown;
    }

    void OnDisable()
    {
        GP_Ads.OnRewardedReward -= OnRewardShown;
    }

    void Start()
    {
        GameManager.Instance.Wave = GP_Player.GetInt("wave");

        _levelTime = (int)(GameManager.Instance.Level * 45);

        _levelTimerTXT.text = _levelTime.ToString();
        InvokeRepeating("WorkTimer", 0f, 1f);
        _levelMoooneyTXT.text = _levelMoooney.ToString();

        _winCNV.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Invoke(nameof(LockTheCursor), 1f);

        _waveNumTXT.text = GameManager.Instance.Wave.ToString();
    }

    void LockTheCursor()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void WorkTimer()
    {
        if (_levelTime > 0)
        {
            _levelTime--;
            _levelTimerTXT.text = _levelTime.ToString();
        }
        else
        {
            Win();
        }
    }

    public void AddMoney(int moooney)
    {
        _levelMoooney += moooney;
        _levelMoooneyTXT.text = _levelMoooney.ToString();
    }

    void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        Progression();

        _winCNV.SetActive(true);
        _doubleRewardBTN.onClick.AddListener(ShowRewardAd);
        _menuBTN.onClick.AddListener(ToMenu);
    }

    void Progression()
    {
        if (GameManager.Instance.Level < 3)
        {
            GameManager.Instance.Level += .1f;
        }

        if (GameManager.Instance.HouseHealthMultiplier < 2)
        {
            GameManager.Instance.HouseHealthMultiplier += .1f;
        }
    }

    void ShowRewardAd()
    {
        GP_Ads.ShowRewarded("double");
    }

    void GetReward(string id)
    {
        if (id == "double")
        {
            _levelMoooney *= 2;
            _levelMoooneyTXT.text = _levelMoooney.ToString();
            ToMenu();
        }
    }

    void OnRewardShown(string id)
    {
        if (id == "double")
            GetReward("double");
    }

    void ToMenu()
    {
        Time.timeScale = 1f;
        MoneyManager.Instance.TotalMoney += _levelMoooney;
        GameManager.Instance.Wave++;
        GP_Player.Set("wave", GameManager.Instance.Wave);
        GP_Player.Set("money", MoneyManager.Instance.TotalMoney);
        GP_Player.Sync();
        SceneSwitcher.Instance.SwitchScene(0);
    }

    public int GetMoooney() => _levelMoooney;
}
