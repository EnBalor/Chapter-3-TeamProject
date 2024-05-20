using UnityEngine;

[CreateAssetMenu(fileName = "BaseData", menuName = "Dodge/BaseData")]
public class StatSO : ScriptableObject
{
    [Header("Character Info")]
    public int health;
    public float speed;

    [Header("Attack Info")]
    public float attackDelay;
    public float attackPower;
    public float attackSpeed;
    public LayerMask target;

    [Header("Projectile Info")]
    public string nameTag;
    public float size;
    public float duration;
    public float spread;
    public int numberOfProjectiles;
    public float projectilesAngle;
    public Color projectileColor;
}
