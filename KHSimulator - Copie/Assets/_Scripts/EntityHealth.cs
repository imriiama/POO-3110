using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    public UnityEvent<int, int> OnHealthChanged;
    public UnityEvent OnDeath; 

    private Animator _animator;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogWarning("Animator non trouvé sur " + gameObject.name);
        }
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0) return; 

        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die(); 
        }

        OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        _maxHealth = newMaxHealth;
        CurrentHealth = Mathf.Min(CurrentHealth, _maxHealth);
        OnHealthChanged?.Invoke(CurrentHealth, _maxHealth);
    }

    private void Die()
    {
        OnDeath?.Invoke(); 

        if (_animator != null)
        {
            _animator.SetTrigger("Die"); 
        }

        Debug.Log(gameObject.name + " est mort.");

        if (TryGetComponent(out PlayerMove playerMove))
        {
            playerMove.enabled = false;
        }
    }
}





