using UnityEngine;
using GamePush;

public class SetupGun : MonoBehaviour
{
    public bool IsSold;

    void OnEnable()
    {
        int id = GetComponent<Gun>().WpID;

        if (id == GP_Player.GetInt($"wpIds{id}"))
        {
            IsSold = true;
        }
    }
}

