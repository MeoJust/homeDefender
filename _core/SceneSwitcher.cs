using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance { get; private set; }

    public int[] WpOnLevelIds = new int[3];

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SwitchScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void SetTheGoonz(int[] ids)
    {
        WpOnLevelIds = ids;
    }

    public int[] GetTheGoonz()
    {
        return WpOnLevelIds;
    }
}
