using System;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<CharacterStat> OnAttackEvent;

    protected CharacterStatHandler statHandler;

    protected bool IsAttacking { get; set; }
    private float _timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(CharacterStat currentStat)
    {
        OnAttackEvent?.Invoke(currentStat);
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= statHandler.currentStat.attackDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > statHandler.currentStat.attackDelay)
        {
            _timeSinceLastAttack = 0f;
            CallAttackEvent(statHandler.currentStat);
        }
    }
}
