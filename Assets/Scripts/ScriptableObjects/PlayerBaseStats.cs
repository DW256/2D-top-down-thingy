using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBaseStats : ScriptableObject
{
    public int MaxHealth = 5;
    public float MovementSpeed = 5f;
    public float ShootIntervalModifier = 1f;
    public float BulletSpeedModifier = 1f;
    public float DamageModifier = 1f;
    public float KnockbackModifier = 1f;
}
