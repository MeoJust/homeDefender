using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int _levelTime = 69;
    [SerializeField] TextMeshProUGUI _levelTimerTXT;
    [SerializeField] TextMeshProUGUI _levelMoooneyTXT;

    public int ZumbyOnLevel = 10;
    int _levelMoooney = 0;

    void Start()
    {
        _levelTimerTXT.text = _levelTime.ToString();
        InvokeRepeating("WorkTimer", 0f, 1f);
        _levelMoooneyTXT.text = _levelMoooney.ToString();
    }

    void WorkTimer()
    {
        if (_levelTime > 0)
        {
            _levelTime--;
            _levelTimerTXT.text = _levelTime.ToString();
        }
    }

    public void AddMoney(int moooney)
    {
        _levelMoooney += moooney;
        _levelMoooneyTXT.text = _levelMoooney.ToString();
    }
}
