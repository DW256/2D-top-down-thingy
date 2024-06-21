using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunBaseStats baseStats;
    //private int damage;
    //private float knockback;
    //private float bulletSpeed;
    //private float shootInterval;


    public Transform Muzzle;
    public float FlashingFrame = 2f;

    public SpriteRenderer Sprite { get; private set; }
    public SpriteRenderer MuzzleFlash { get; private set; }
    public ObjectPool<Bullet> BulletPool;

    private float flashedFrame = 0f;
    private bool isFlash = false;

    private float cooldown = 0f;
    public bool canShoot { get; private set; }


    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();

        MuzzleFlash = Muzzle.GetComponent<SpriteRenderer>();
        MuzzleFlash.enabled = false;
        
        canShoot = true;

    }

    private void Update()
    {
        if (!canShoot) ProcessCooldown();
        if (isFlash) ProcessFlash();
    }

    private void ProcessCooldown()
    {
        cooldown -= Time.deltaTime;
        canShoot = cooldown <= 0f;
    }

    public void ForceCooldownEnds()
    {
        canShoot = true;
    }

    //public void Shoot(Quaternion rotation, float damageModifier, float bulletSpeedModifier,float knockbackModifier, float shootIntervalModifier)
    public void Shoot(float damageModifier, float bulletSpeedModifier, float knockbackModifier, float shootIntervalModifier, Collider2D shooter)
    {
        if (!canShoot) return;
        isFlash = true;
        canShoot = false;
        cooldown = baseStats.ShootInterval * shootIntervalModifier;

        //Spawn bullet
        Bullet bullet = BulletPool.Get();
        bullet.transform.position = Muzzle.transform.position;
        //bullet.transform.rotation = rotation;

        //set attack
        int damage = (int)Mathf.CeilToInt(baseStats.BaseDamage * damageModifier);
        float knockback = baseStats.BaseKnockback * knockbackModifier;
        bullet.SetAttack(damage, knockback, shooter);

        float bulletSpeed = baseStats.BulletSpeed * bulletSpeedModifier;
        bullet.Rigidbody.AddForce(Muzzle.transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    private void ProcessFlash()
    {
        MuzzleFlash.enabled = true;

        if (flashedFrame < FlashingFrame)
        {
            flashedFrame += Time.deltaTime;
            return;
        }

        flashedFrame = 0f;
        MuzzleFlash.enabled = false;
        isFlash = false;
    }
}
