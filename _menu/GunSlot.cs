using UnityEngine;

public class GunSlot : MonoBehaviour
{
    [SerializeField] bool _isEmpty = true;
    [SerializeField] int _id;

    [SerializeField] GameObject[] _goonz;

    SetupManager _setupManager;

    void Awake()
    {
        _setupManager = FindObjectOfType<SetupManager>();
    }

    void Start()
    {
        HideAll();

        _setupManager.ClearSlots += ClearSlot;
    }

    public void SetTheGun(int id)
    {
        if (!_isEmpty) return;
        HideAll();
        _goonz[id].SetActive(true);

        _isEmpty = false;
    }

    void ClearSlot()
    {
        if (_isEmpty) return;

        HideAll();
        _isEmpty = true;
    }

    void HideAll()
    {
        foreach (var gun in _goonz)
        {
            gun.SetActive(false);
        }
    }

    public bool IsEmpty => _isEmpty;
    public int Id => _id;
}
