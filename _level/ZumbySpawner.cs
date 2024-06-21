using UnityEngine;

public class ZumbySpawner : MonoBehaviour
{
    [SerializeField] GameObject _zumby;

    void Start()
    {
        InvokeRepeating("SpawnZumby", 0f, 3f);
    }
    void SpawnZumby()
    {
        Instantiate(_zumby, transform.position, Quaternion.identity);
    }
}
