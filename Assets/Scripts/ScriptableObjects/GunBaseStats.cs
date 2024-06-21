using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunBaseStats : ScriptableObject
{
    public int BaseDamage = 1;
    public float BaseKnockback= 1f;
    public float BulletSpeed = 20f;
    public float ShootInterval = 3f;
}
