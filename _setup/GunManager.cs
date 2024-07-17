using UnityEngine;
using GamePush;

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

    public int[] BuyedGunz = new int[16];

    void Start()
    {
        foreach (var gun in BuyedGunz)
        {
            //print(gun);
        }


        Invoke(nameof(LoadGoonz), .25f);
    }

    public void SetTheInventory(int id)
    {
        BuyedGunz[id] = id;
        GP_Player.Set($"wpIds{id}", id);
    }

    void LoadGoonz()
    {
        foreach (var gun in BuyedGunz)
        {
            // print(gun);
        }

        FindObjectOfType<SetupManager>().CheckIfIsSold();
    }
}
