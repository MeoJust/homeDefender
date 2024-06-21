using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int _wpID;
    [SerializeField] int _wpCost;
    [SerializeField] string _wpName;

    [SerializeField] float _damage;

    public int WpID => _wpID;
    public int WpCost => _wpCost;
    public string WpName => _wpName;

    public float Damage => _damage;
}
