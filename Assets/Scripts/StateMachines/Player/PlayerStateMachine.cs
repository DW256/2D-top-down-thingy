using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public PlayerBaseStats BaseStats { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public Collider2D Collider { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Transform Aim { get; private set; }
    [field: SerializeField] public SpriteRenderer AvatarSprite { get; private set; }
    [field: SerializeField] public Gun Gun { get; private set; }
    [field: SerializeField] public BulletSpawner BulletSpawner { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    public float MovementSpeed { get; private set; }
    public float ShootIntervalModifier { get; private set; }
    public float DamageModifier { get; private set; }
    public float BulletSpeedModifier { get; private set; }
    public float KnockbackModifier { get; private set; }

    private void Awake()
    {
        MovementSpeed = BaseStats.MovementSpeed;
        ShootIntervalModifier = BaseStats.ShootIntervalModifier;
        DamageModifier = BaseStats.DamageModifier;
        BulletSpeedModifier = BaseStats.BulletSpeedModifier;
        KnockbackModifier = BaseStats.KnockbackModifier;
        Health.MaxHealth = BaseStats.MaxHealth;

    }

    private void Start()
    {
        Gun.BulletPool = BulletSpawner.Pool;
        SwitchState(new PlayerIdleState(this));
    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        //SwitchState(new PlayerImpactState(this));
    }

    private void HandleDie()
    {
        //SwitchState(new PlayerDeadState(this));
    }

}
