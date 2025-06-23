using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CommonEnemySpawn : SpawnEnemy
{
    private int waveNumber = 0;
    private int spawnSize = 5;
    private void Awake()
    {
        enemyPrefabs = Resources.LoadAll<GameObject>(TagInGame.enemy);

        hoderObject = transform.Find("HolderEnemy");
    }

    private void OnEnable()
    {
        pool = new ObjectPool<List<GameObject>>(enemyPrefabs, size, hoderObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawmByWave(spawnSize);
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

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.X))
        {
            SpawmByWave(spawnSize);
        }
        // ta cac gaem object torng pool
        if (!pool.HasActiveObject())
        {
            SpawmByWave(spawnSize);
        }
    }
}
