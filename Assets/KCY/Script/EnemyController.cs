using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : DodgeController
{
    protected Transform closeTarget { get; private set; }
    GameManager gameManager;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.instance;
        closeTarget = gameManager.player;
    }

    protected virtual void FixedUpdate()
    {
        
    }


    protected float DistanceTarget()
    {
        return Vector3.Distance(transform.position, closeTarget.position);
    }

    protected Vector2 DirTarget()
    {
        return (closeTarget.position - transform.position).normalized;
    }
}
