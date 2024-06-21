using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public AIPath AIPath { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public SpriteRenderer AvatarSprite { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public AudioSource Audio { get; private set; }
    [field: SerializeField] private EnemyCollision Collision;
    public ObjectPool<EnemyStateMachine> myPool;

    public Health Player;

    [SerializeField] private float speed = 4;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damage = 15;
    [SerializeField] private int knockback = 20;

    private void Awake()
    {
        Health.MaxHealth = maxHealth;
        AIPath.maxSpeed = speed;
        Collision.SetAttack(damage,knockback);
    }
    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }
        SwitchState(new EnemyChasingState(this));
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
        Audio.Play();
        myPool.Release(this);
        //SwitchState(new PlayerDeadState(this));
    }
}
