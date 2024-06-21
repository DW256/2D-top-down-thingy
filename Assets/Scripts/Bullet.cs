using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    
    
    private int damage;
    private float knockback;

    private Collider2D shooter;
    private Animator _animator;

    public ObjectPool<Bullet> myPool;
    public Rigidbody2D Rigidbody { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        _animator.SetTrigger("Dissapate");
        if (collision.collider == shooter) { Debug.Log("Self Hit"); }

        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }

        if (collision.gameObject.TryGetComponent<ForceReceiver>(out ForceReceiver fr))
        {
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            fr.AddForce(direction * knockback);
        }
    }

    public void DestroySelf()
    {
        myPool.Release(this);
    }

    public void SetAttack(int damage, float knockback, Collider2D shooter)
    {
        this.damage = damage;
        this.knockback = knockback;
        this.shooter = shooter;
    }

}
