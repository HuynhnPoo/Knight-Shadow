using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour, ISpawn
{

    [SerializeField] private GameObject[] enemyPrefabs;

    int size = 100;
    private int spawnSize = 5;
    private int waveNumber = 0;

    private ObjectPool<List<GameObject>> pool;

    [SerializeField] private Transform hoderObject;

    private void Awake()
    {
        enemyPrefabs = Resources.LoadAll<GameObject>(TagInGame.enemy);

        hoderObject = transform.Find("HolderEnemy");
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        pool = new ObjectPool<List<GameObject>>(enemyPrefabs, size, hoderObject);
    }


    void Start()
    {
        SpawmByWave(spawnSize);
    }


    // Update is called once per frame
    void Update()
    {

        // ta cac gaem object torng pool
        if (!pool.HasActiveObject())
        {
            SpawmByWave(spawnSize);
        }
    }

    // hàm sinh enemy theo lượt
    void SpawmByWave(int spawnSize)
    {
        waveNumber += 1;
        this.spawnSize += 5;
        Vector2 posSpawn;
        int spawnX = 18;
        int spawnY = 6;

        // khoi tao cac enemy
        for (int i = 0; i < spawnSize; i++)
        {
            // khoang cach, vi tri  sinh ra enemy
            posSpawn = GameManager.Instance.PlayerCrtl.transform.position;
            posSpawn.x = Random.Range(-spawnX, spawnX);
            posSpawn.y = Random.Range(-spawnY, spawnY);

            Spawning(posSpawn);
        }
    }

    public void Spawning(Vector2 posSpawn)
    {
        GameObject enemy = pool.GetObject(); // lay ra enemy tu pool
        if (enemy != null)
        {
            enemy.transform.position = posSpawn;// khoi taoj vi tri cho enemy
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        pool.ReturnObject(obj);
    }
}
