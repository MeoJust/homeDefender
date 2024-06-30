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

    float _health;

    void Start()
    {
        HealthSetUp();

        _restartBTN.onClick.AddListener(Restart);
        _menuBTN.onClick.AddListener(ToMenu);
        _adBTN.onClick.AddListener(Rewind);
        _gameOverCNV.SetActive(false);

    }

    void HealthSetUp()
    {
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
            Time.timeScale = 0;
            _gameOverCNV.SetActive(true);

        }
    }

    void Rewind()
    {
        Time.timeScale = 1f;
        HealthSetUp();
        _gameOverCNV.SetActive(false);
    }

    void ToMenu()
    {
        Time.timeScale = 1f;
        SceneSwitcher.Instance.SwitchScene(0);
    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneSwitcher.Instance.SwitchScene(2);
    }
}
