using System;
using UnityEngine;

[Serializable]
public class CharacterStat
{
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}
