using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _startBTN;

    void Start()
    {
        _startBTN.onClick.AddListener(ToSetScene);
    }

    void ToSetScene()
    {
        SceneSwitcher.Instance.SwitchScene(1);
    }
}
