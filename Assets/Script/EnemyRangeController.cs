using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    private int layerMaskLevel;
    private int layermaskTarget;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        layerMaskLevel = LayerMask.NameToLayer("Level");
        layermaskTarget = statHandler.CurrentStat.attackSO.target;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceTarget = DistanceTarget();
        Vector2 dirTarget = DirTarget();

        EnemyState(distanceTarget, dirTarget);
    }

    private void EnemyState(float distanceTarget, Vector2 dirTarget)
    {
        IsAttacking = false;
        CheckNear(distanceTarget, dirTarget);
    }

    private void CheckNear(float distnace, Vector2 dir)
    {
        if (distnace <= shootRange)
        {
            ShootTarget(dir);
        }

        else
        {
            CallMoveEvent(dir);
            CallLookEvent(dir);
        }
    }

    private void ShootTarget(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, shootRange, GetLayerMaskRaycast());

        if (isTargetHit(hit))
        {
            AttackAction(dir);
        }

        else
        {
            CallMoveEvent(dir);
            CallLookEvent(dir);
        }
    }

    private int GetLayerMaskRaycast()
    {
        return (1 << layermaskTarget | layermaskTarget);
    }

    private bool isTargetHit(RaycastHit2D hit)
    {
        return hit.collider != null && layermaskTarget == (layermaskTarget | (1 << hit.collider.gameObject.layer));
    }

    private void AttackAction(Vector2 dir)
    {
        CallLookEvent(dir);
        CallMoveEvent(Vector2.zero);
        IsAttacking = true;
    }
}
