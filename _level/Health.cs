using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _maxHealth = 100f;

    Animator _animator;
    Character _player;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Character>();
    }

    public void IsHit()
    {
        _maxHealth -= _player.GetComponentInChildren<Gun>().Damage;
        print(_maxHealth);
        if (_maxHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _animator.SetInteger("animId", Random.Range(0, 3));
        _animator.applyRootMotion = true;
        _animator.SetTrigger("isDead");
        GetComponent<Collider>().enabled = false;
    }
}
