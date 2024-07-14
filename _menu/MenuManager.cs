using UnityEngine;
using UnityEngine.UI;
using GamePush;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _startBTN;
    [SerializeField] Button _rusBTN;
    [SerializeField] Button _engBTN;
    [SerializeField] Slider _volumeSlider;

    void Start()
    {
        _startBTN.onClick.AddListener(ToSetScene);

        _rusBTN.onClick.AddListener(SetRusLang);
        _engBTN.onClick.AddListener(SetEngLang);

        _volumeSlider.value = AudioManager.Instance.MusicVolume;

        _volumeSlider.onValueChanged.AddListener(SetMusicVolume);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        ShowFullScreenAd();
    }

    void ShowFullScreenAd()
    {
        GP_Ads.ShowFullscreen();
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

    void SetRusLang()
    {
        PlayerPrefs.SetString("language", "rus");

        var txts = FindObjectsOfType<LocTXT>();
        foreach (var txt in txts)
        {
            txt.SetRusLang();
        }
    }

    void SetEngLang()
    {
        PlayerPrefs.SetString("language", "eng");

        var txts = FindObjectsOfType<LocTXT>();
        foreach (var txt in txts)
        {
            txt.SetEngLang();
        }
    }
}
