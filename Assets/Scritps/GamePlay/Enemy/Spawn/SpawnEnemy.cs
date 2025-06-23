using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnEnemy : MonoBehaviour, ISpawn
{

    [SerializeField] protected GameObject[] enemyPrefabs;

   protected int size = 100;  

    protected ObjectPool<List<GameObject>> pool;

    [SerializeField] protected Transform hoderObject;
    
    public virtual void Spawning(Vector2 posSpawn)
    {
        GameObject enemy = pool.GetObject(); // lay ra enemy tu pool
        if (enemy != null)
        {
            enemy.transform.position = posSpawn;// khoi taoj vi tri cho enemy
            enemy.transform.rotation = Quaternion.identity;
        }
    }

    public virtual void ReturnToPool(GameObject obj)
    {
        pool.ReturnObject(obj);
    }
}
