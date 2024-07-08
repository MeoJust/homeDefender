using TMPro;
using UnityEngine;

public class LocTXT : MonoBehaviour
{
    [SerializeField] string _rusTXT;
    [SerializeField] string _engTXT;

    TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = gameObject.GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.GetString("language", "rus") == "rus")
        {
            SetRusLang();
        }
        else
        {
            SetEngLang();
        }
    }

    public void SetRusLang()
    {
        if (!_textComponent) return;

        _textComponent.text = _rusTXT;
    }

    public void SetEngLang()
    {
        if (!_textComponent) return;

        _textComponent.text = _engTXT;
    }
}
