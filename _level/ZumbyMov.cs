using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZumbyMov : MonoBehaviour
{
    [SerializeField] GameObject[] _meshes;
    Target[] _targets;

    NavMeshAgent _agent;
    Rigidbody _rb;
    Animator _animator;
    Health _health;

    HouseHealth _houseHealth;

    Transform _targetToMove;

    public bool IsAlive = true;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();

        _animator.SetInteger("animId", Random.Range(0, 3));
    }

    void Start()
    {
        _houseHealth = FindObjectOfType<HouseHealth>();

        _targets = FindObjectsOfType<Target>();

        _targetToMove = _targets[Random.Range(0, _targets.Length)].transform;

        foreach (var mesh in _meshes)
        {
            mesh.SetActive(false);
        }

        _meshes[Random.Range(0, _meshes.Length)].SetActive(true);
    }

    void Update()
    {
        if (!_agent.enabled) return;
        if(_health.GetHealth() <= 0){ IsAlive = false; }


        _agent.SetDestination(_targetToMove.position);
        var distanceToTarget = Vector3.Distance(transform.position, _targetToMove.position);
//        print(distanceToTarget);

        if (distanceToTarget <= 1f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(!IsAlive) return;

        _animator.SetInteger("animId", Random.Range(0, 3));
        _animator.SetBool("isOnTarget", true);

        transform.LookAt(Vector3.zero);

        _agent.isStopped = true;
        _agent.velocity = Vector3.zero;
        _agent.enabled = false;
        _rb.isKinematic = true;

        StartCoroutine(AttackRate());
    }

        IEnumerator AttackRate()
    {
        while (IsAlive) 
        {
            _houseHealth.TakeDamage(5f);

            yield return new WaitForSeconds(2f); // Ожидание трех секунд
        }
    }
}
