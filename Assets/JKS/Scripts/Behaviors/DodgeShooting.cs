using UnityEngine;

public class DodgeShooting : MonoBehaviour
{
    private DodgeController _controller;
    private Vector2 _aimDirection = Vector2.up;

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
        _aimDirection = direction;
    }

    private void OnShoot(CharacterStat currentStat)
    {
        float projectilesAngleSpace = currentStat.projectilesAngle;
        int numberOfProjectilesPerShot = currentStat.numberOfProjectiles;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * currentStat.projectilesAngle;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-currentStat.spread, currentStat.spread);
            angle += randomSpread;
            CreateProjectile(currentStat, angle);
        }
    }

    private void CreateProjectile(CharacterStat currentStat, float angle)
    {
        GameObject obj = SpawnManager.instance.ObjectPool.SpawnFromPool(currentStat.nameTag);

        obj.transform.position = transform.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(_aimDirection, angle), currentStat);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * v;
    }
}
