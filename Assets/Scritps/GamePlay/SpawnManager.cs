using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private ObjectPoolBase pool;

    // [SerializeField] private CharacterInfo characterInfo;

    private int spawnSize = 5;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (pool != null) return;
        pool = GetComponent<ObjectPoolList>();
    }

    void Start()
    {
        SpawmByWave(spawnSize);
    }


    // Update is called once per frame
    void Update()
    {
        if (pool is ObjectPoolList poolling)
        {
            Debug.Log("hien thi pooling true or fasle:" + poolling.HasActiveObject());
            if (!poolling.HasActiveObject())
            {
                Debug.Log("thuc hien spawn");
                SpawmByWave(9);
            }
        }
    }

    // hàm sinh enemy theo lượt
    void SpawmByWave(int spawnSize)
    {

        Vector2 posSpawn;
        for (int i = 0; i < spawnSize; i++)
        {
            posSpawn=GameManager.Instance.PlayerCrtl.transform.position;
            posSpawn.x = Random.Range(-5f,5f);
            posSpawn.y = Random.Range(-5f, 5f);


            GameObject enemy = pool.GetObjectPool();
            if (enemy != null) {
                enemy.transform.position = posSpawn;
            }
        }
    }
}
