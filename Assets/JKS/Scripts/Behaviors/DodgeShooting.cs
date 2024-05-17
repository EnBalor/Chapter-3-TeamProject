using UnityEngine;

public class DodgeShooting : MonoBehaviour
{
    private DodgeController _controller;
    private Vector2 aimDirection = Vector2.up;

    private void Awake()
    {
        _controller = GetComponent<DodgeController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
        _controller.OnAttackEvent += OnShoot;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot(AttackSO attackSO)
    {
        float projectilesAngleSpace = attackSO.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = attackSO.numberofProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * attackSO.multipleProjectilesAngel;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-attackSO.spread, attackSO.spread);
            angle += randomSpread;
            CreateProjectile(attackSO, angle);
        }
    }

    private void CreateProjectile(AttackSO attackSO, float angle)
    {
        GameObject obj = SpawnManager.instance.ObjectPool.SpawnFromPool(attackSO.bulletNameTag);

        obj.transform.position = transform.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), attackSO);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * v;
    }
}
