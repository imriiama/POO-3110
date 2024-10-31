using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private InputActionReference _attackAction;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damage = 10;
    [SerializeField] private Collider attackRange;
    private UnityEvent OnAttack = new UnityEvent(); 

    public UnityEvent AttackEvent => OnAttack; 

    private bool canAttack = true;

    private void Start()
    {
        _attackAction.action.performed += PerformAttack;
    }

    private void OnDestroy()
    {
        _attackAction.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            OnAttack.Invoke();
            Debug.Log("Attaque déclenchée !");

            canAttack = false;
            StartCoroutine(AttackRoutine());

            Invoke(nameof(ResetAttack), attackCooldown);
        }
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        Collider[] hitColliders = Physics.OverlapBox(attackRange.bounds.center, attackRange.bounds.extents, attackRange.transform.rotation);
        foreach (var hitCollider in hitColliders)
        {
            var health = hitCollider.GetComponent<EntityHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}


