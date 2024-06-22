using UnityEngine;
using UnityEngine.Pool;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect effect;
    public ObjectPool<PowerUp> myPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        effect.Apply(collision.gameObject);
        myPool.Release(this);
    }
}