using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class PowerUpSpawner : MonoBehaviour
{
    public PowerUp puPrefab;
    public ObjectPool<PowerUp> Pool;
    public List<PowerUpEffect> PowerUpList;

    void Awake()
    {
        Pool = new ObjectPool<PowerUp>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
    }

    PowerUp OnObjectCreate()
    {
        PowerUp obj = Instantiate(puPrefab, this.transform);
        obj.myPool = Pool;
        return obj;
    }

    void OnTake(PowerUp obj)
    {
        obj.gameObject.SetActive(true);
        PowerUpEffect fx = PowerUpList[Random.Range(0,PowerUpList.Count)];
        obj.gameObject.GetComponent<SpriteRenderer>().sprite = fx.Sprite;
        obj.effect = fx;
    }

    void OnRelease(PowerUp obj)
    {
        obj.gameObject.SetActive(false);
    }

    void OnObjectDestroy(PowerUp obj)
    {
        Destroy(obj.gameObject);
    }

}
