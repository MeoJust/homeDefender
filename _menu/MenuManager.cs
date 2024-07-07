using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _startBTN;
    [SerializeField] Slider _volumeSlider;

    void Start()
    {
        _startBTN.onClick.AddListener(ToSetScene);

        _volumeSlider.value = AudioManager.Instance.MusicVolume;

        _volumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    void ToSetScene()
    {
        SceneSwitcher.Instance.SwitchScene(1);
    }

    void SetMusicVolume(float value)
    {
        AudioManager.Instance.MusicVolume = value;
        PlayerPrefs.SetFloat("MusicVolume", AudioManager.Instance.MusicVolume);
    }
}
