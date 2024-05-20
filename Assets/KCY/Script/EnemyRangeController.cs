using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    private int layerMaskLevel;
    private int layermaskTarget;

    Vector2 dirTarget;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        layerMaskLevel = LayerMask.NameToLayer("Level");
        layermaskTarget = statHandler.currentStat.target;
        dirTarget = DirTarget();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceTarget = DistanceTarget();

        CallMoveEvent(dirTarget);
        CallLookEvent(dirTarget);
        EnemyState(distanceTarget);
    }

    private void EnemyState(float distanceTarget)
    {
        IsAttacking = false;
        CheckNear(distanceTarget);
    }
    
    private void CheckNear(float distnace)
    {
        if (distnace <= shootRange)
        {
            ShootTarget(dirTarget);
        }

        if (transform.position.x < -10f || transform.position.x > 10f || transform.position.y > 6f || transform.position.y < -6f)
        {
            //Destroy(gameObject);
        }
    }

    private void ShootTarget(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, shootRange, GetLayerMaskRaycast());

        if (isTargetHit(hit))
        {
            AttackAction(dir);
        }
    }

    private int GetLayerMaskRaycast()
    {
        return layermaskTarget;
    }

    private bool isTargetHit(RaycastHit2D hit)
    {
        return hit.collider != null && layermaskTarget == (layermaskTarget | (1 << hit.collider.gameObject.layer));
    }

    private void AttackAction(Vector2 dir)
    {
        IsAttacking = true;
    }
}
