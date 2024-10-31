using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField, Required] private Animator _animator;
    [SerializeField, Required] private PlayerMove _move;
    [SerializeField] private PlayerAttack _attack;
    [SerializeField] private EntityHealth _health;

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Bool)]
    [SerializeField] private string _isWalkingBoolParam = "Walking";

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] private string _attackTriggerParam = "Attack";

    [AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Trigger)]
    [SerializeField] private string _takeDamageTriggerParam = "TakeDamage";

    private void Reset()
    {
        _animator = GetComponent<Animator>();
        _move = GetComponentInParent<PlayerMove>();
        _attack = GetComponentInParent<PlayerAttack>();
        _health = GetComponentInParent<EntityHealth>();

        _isWalkingBoolParam = "Walking";
        _attackTriggerParam = "Attack";
        _takeDamageTriggerParam = "TakeDamage";
    }

    private void Start()
    {
        _move.OnStartMove += _move_OnStartMove;
        _move.OnStopMove += _move_OnStopMove;

        _attack.AttackEvent.AddListener(_attack_OnAttack);

        _health.OnHealthChanged.AddListener(_takeDamage_OnHealthChanged);
    }

    private void _move_OnStartMove()
    {
        _animator.SetBool(_isWalkingBoolParam, true);
    }

    private void _move_OnStopMove()
    {
        _animator.SetBool(_isWalkingBoolParam, false);
    }

    private void _attack_OnAttack()
    {
        _animator.SetTrigger(_attackTriggerParam);
    }

    private void _takeDamage_OnHealthChanged(int currentHealth, int maxHealth)
    {
        if (currentHealth < maxHealth)
        {
            _animator.SetTrigger(_takeDamageTriggerParam);
        }
    }
}


