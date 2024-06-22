using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private int damage;
    private float knockback;
    private ForceReceiver sfr;

    private void Awake()
    {
        sfr = GetComponent<ForceReceiver>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }

        if (collision.gameObject.TryGetComponent<ForceReceiver>(out ForceReceiver fr))
        {
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            fr.AddForce(direction * knockback);
            sfr.AddForce(direction * knockback * -1);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
