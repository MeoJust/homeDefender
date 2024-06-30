using UnityEngine;

public class ZumbySpawner : MonoBehaviour
{
    [SerializeField] GameObject _zumby;

    LevelManager _levelManager;

    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        InvokeRepeating("SpawnZumby", 0f, 3f);
    }
    void SpawnZumby()
    {
        ZumbyMov[] zumbys = FindObjectsOfType<ZumbyMov>();

        if (_levelManager.ZumbyOnLevel >= zumbys.Length)
        {
            Instantiate(_zumby, transform.position, Quaternion.identity);
            // _levelManager.ZumbyOnLevel--;
            // print(_levelManager.ZumbyOnLevel);
        }
        else
        {
            print("no more zumby");
        }
    }
}
