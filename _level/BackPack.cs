using UnityEngine;

public class BackPack : MonoBehaviour
{
    [SerializeField] Gun[] _guns;

    void Awake()
    {
        foreach (var id in SceneSwitcher.Instance.GetTheGoonz())
        {
            foreach (var gun in _guns)
            {
                if (gun.WpID == id)
                {
                    GameObject goon =Instantiate(gun.gameObject, transform.position, Quaternion.identity);
                    goon.transform.SetParent(transform, false);
                    goon.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
