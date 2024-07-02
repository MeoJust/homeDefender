using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int _levelTime = 69;
    [SerializeField] TextMeshProUGUI _levelTimerTXT;
    [SerializeField] TextMeshProUGUI _levelMoooneyTXT;
    [SerializeField] GameObject _winCNV;
    [SerializeField] Button _doubleRewardBTN;
    [SerializeField] Button _menuBTN;

    public int ZumbyOnLevel = 10;
    int _levelMoooney = 0;

    void Start()
    {
        _levelTimerTXT.text = _levelTime.ToString();
        InvokeRepeating("WorkTimer", 0f, 1f);
        _levelMoooneyTXT.text = _levelMoooney.ToString();

        _winCNV.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Cursor.visible = true;
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
        _winCNV.SetActive(true);
        _doubleRewardBTN.onClick.AddListener(GetReward);
        _menuBTN.onClick.AddListener(ToMenu);
    }

    void GetReward()
    {
        _levelMoooney *= 2;
        _levelMoooneyTXT.text = _levelMoooney.ToString();
        ToMenu();
    }

    void ToMenu()
    {
        Time.timeScale = 1f;
        MoneyManager.Instance.TotalMoney += _levelMoooney;
        SceneSwitcher.Instance.SwitchScene(0);
    }

    public int GetMoooney() => _levelMoooney;
}
