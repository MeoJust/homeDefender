using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int[] BuyedGunz = new int[18];

    void Start()
    {
        foreach (var gun in BuyedGunz)
        {
            print(gun);
        }
    }

    public void SetTheInventory(int id)
    {
        BuyedGunz[id] = id;
    }
}
