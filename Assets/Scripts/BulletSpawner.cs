using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public Bullet bulletPrefab;
    public ObjectPool<Bullet> Pool;

    void Awake()
    {
        Pool = new ObjectPool<Bullet>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
    }

    Bullet OnObjectCreate()
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform); 
        bullet.myPool = Pool;
        return bullet;
    }

    void OnTake(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    void OnObjectDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}