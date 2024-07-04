using UnityEngine;
using UnityEngine.UI;

public class HouseHealth : MonoBehaviour
{
    [SerializeField] Slider _healthSlider;
    [SerializeField] GameObject _gameOverCNV;
    [SerializeField] Button _adBTN;
    [SerializeField] Button _restartBTN;
    [SerializeField] Button _menuBTN;

    [SerializeField] float _maxHealth = 100f;


    LevelManager _levelManager;

    float _health;

    void Start()
    {
        HealthSetUp();

        _levelManager = FindObjectOfType<LevelManager>();

        _restartBTN.onClick.AddListener(Restart);
        _menuBTN.onClick.AddListener(ToMenu);
        _adBTN.onClick.AddListener(Rewind);

        _gameOverCNV.SetActive(false);

    }

    void HealthSetUp()
    {
        _maxHealth = GameManager.Instance.HouseHealthMultiplier * 500f;

        _health = _maxHealth;
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthSlider.value = _health;
        if (_health <= 0)
        {
            Loose();

        }
    }

    void Loose()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _gameOverCNV.SetActive(true);
    }

    void Rewind()
    {
        Time.timeScale = 1f;
        HealthSetUp();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _gameOverCNV.SetActive(false);
    }

    void ToMenu()
    {
        Time.timeScale = 1f;
        MoneyManager.Instance.TotalMoney += _levelManager.GetMoooney();
        SceneSwitcher.Instance.SwitchScene(0);
    }

    void Restart()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneSwitcher.Instance.SwitchScene(2);
    }
}
