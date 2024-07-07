using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;
    [SerializeField] int _lifeCost = 10;

    [SerializeField] GameObject[] _hitVFX;
    [SerializeField] GameObject[] _hitHeadVFX;

    LevelManager _levelManager;

    Animator _animator;
    Character _player;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Character>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    public void IsHit(Vector3 hitPoint)
    {
        _maxHealth -= _player.GetComponentInChildren<Gun>().Damage;
        Instantiate(_hitVFX[Random.Range(0, _hitVFX.Length - 1)], hitPoint, Quaternion.identity);
        // print(_maxHealth);
        if (_maxHealth <= 0)
        {
            Die();
        }
    }

    public void IsHitInHead(Vector3 hitPoint){
        _maxHealth -= _player.GetComponentInChildren<Gun>().Damage * 2f;
        Instantiate(_hitHeadVFX[Random.Range(0, _hitVFX.Length - 1)], hitPoint, Quaternion.identity);
        // print("!!HEAD!!");
        // print(_maxHealth);
        if (_maxHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _levelManager.AddMoney(_lifeCost);
        _animator.SetInteger("animId", Random.Range(0, 3));
        _animator.applyRootMotion = true;
        _animator.SetTrigger("isDead");
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 3f);
    }

    public float GetHealth() => _maxHealth;
}
