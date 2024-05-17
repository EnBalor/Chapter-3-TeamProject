using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Move");
        if (distanceTarget < shootRange)
        {
            CheckNear(distanceTarget, dirTarget);
        }
    }

    private void CheckNear(float distnace, Vector2 dir)
    {
        Debug.Log("Move");
        if (distnace <= shootRange)
        {
            ShootTarget(dir);
        }

        else
        {
            CallMoveEvent(dir);
        }
    }

    private void ShootTarget(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, shootRange);
        Debug.Log("Move");

        if (hit.collider != null)
        {
            AttackAction(dir);
        }

        else
        {
            CallMoveEvent(dir);
        }
    }

    private void AttackAction(Vector2 dir)
    {
        CallLookEvent(dir);
        CallMoveEvent(Vector2.zero);
    }
}
