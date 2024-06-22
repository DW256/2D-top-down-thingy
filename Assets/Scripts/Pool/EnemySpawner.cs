using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [Header("Pool")]
    public EnemyStateMachine EnemyPrefab;
    public GameObject CorpsePrefab;
    public ObjectPool<EnemyStateMachine> EnemyPool;
    public ObjectPool<GameObject> CorpsePool;

    [Header("Spawn Manager")]
    public Vector2 minRange;
    public Vector2 maxRange;
    public int InitEnemySpawn = 20;
    public float EnemySpawnInterval = 10f;
    public float EnemySpawnCooldown = 0f;

    public PowerUpSpawner PowerUpSpawner;
    public ObjectPool<PowerUp> PowerUpPool;


    private void Awake()
    {
        EnemyPool = new ObjectPool<EnemyStateMachine>(OnEnemyCreate, OnEnemyTake, OnEnemyRelease, OnEnemyDestroy);
        CorpsePool = new ObjectPool<GameObject>(OnCorpseCreate, OnCorpseTake, OnCorpseRelease, OnCorpseDestroy, true, 20, 20);
        EnemySpawnCooldown = EnemySpawnInterval;

        
    }

    #region ObjectPool
    EnemyStateMachine OnEnemyCreate()
    {
        EnemyStateMachine enemy = Instantiate(EnemyPrefab, this.transform);
        enemy.myPool = EnemyPool;
        return enemy;
    }
    void OnEnemyTake(EnemyStateMachine enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.Health.ResetHealth();
    }
    void OnEnemyRelease(EnemyStateMachine enemy)
    {
        Transform corpse = CorpsePool.Get().transform;
        corpse.position = enemy.transform.position;
        UpdateGraph(corpse.transform);

        if (Random.value < 0.5f)
        {
            Transform pu = PowerUpPool.Get().transform;
            pu.position = enemy.transform.position + new Vector3(1f,1f,0f);
        }
        enemy.gameObject.SetActive(false);
    }
    void OnEnemyDestroy(EnemyStateMachine enemy)
    {
        Destroy(enemy.gameObject);
    }


    GameObject OnCorpseCreate()
    {
        GameObject corpse = Instantiate(CorpsePrefab, this.transform);
        return corpse;
    }
    void OnCorpseTake(GameObject corpse)
    {
        corpse.SetActive(true);
        
    }
    void OnCorpseRelease(GameObject corpse)
    {
        corpse.SetActive(false);
        UpdateGraph(corpse.transform);
    }
    void OnCorpseDestroy(GameObject corpse)
    {
        Destroy(corpse.gameObject);
        UpdateGraph(corpse.transform);
    }

    #endregion

    void UpdateGraph(Transform obj)
    {
        Bounds bounds = obj.GetComponent<Collider2D>().bounds;
        bounds.center = new Vector3(bounds.center.x + obj.transform.position.x, bounds.center.y + obj.transform.position.y, bounds.center.z);
        AstarPath.active.UpdateGraphs(bounds);
        //Debug.Log(bounds);
    }

    private void Start()
    {
        PowerUpPool = PowerUpSpawner.Pool;
        SpawnEnemy(InitEnemySpawn);
    }
    private void FixedUpdate()
    {
        EnemySpawnCooldown -= Time.fixedDeltaTime;
        if (EnemySpawnCooldown <= 0)
        {
            SpawnEnemy();
        }
        if (EnemyPool.CountActive <= 0)
        {
            SpawnEnemy(InitEnemySpawn);
        }
    }
    void SpawnEnemy()
    {
        SpawnEnemy(1);
    }

    void SpawnEnemy(int totalSpawn)
    {
        for (int i = 0; i < totalSpawn; i++)
        {
            EnemyStateMachine enemy = EnemyPool.Get();
            enemy.transform.position = new Vector3(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y), 0f);
        }
        EnemySpawnCooldown = EnemySpawnInterval;
        //Debug.Log($"Spawned {totalSpawn} enemies.");
    }
}
