using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BossEnemySpawn : SpawnEnemy
{

    [Header("variables of boss spawn")]
    public AssetReference[] itemAssets;
    private List<GameObject> list = new List<GameObject>();
    private PositonOfWorld positonOfWorld;
    private int milestoneOfBoss = 5;

    private void Awake()
    {
        size = 5;
        positonOfWorld = new PositonOfWorld();
        list.Clear();
        GameManagerAssetsLoad.LoadingGameAsset(itemAssets, list, this, onLoadBoss); // load các item bang addressable
    }

    public void onLoadBoss()
    {

        hoderObject = transform.Find("HolderBoss");
        if (list != null && list.Count > 0)
        {
            enemyPrefabs = list.ToArray();
            pool = new ObjectPool<List<GameObject>>(enemyPrefabs, size, hoderObject);
        }

    }


    void HandleSpawnBoss()
    {
        int curentLevel = GameManager.Instance.CurrentLevel;
        if (curentLevel == milestoneOfBoss && positonOfWorld != null)// neue maf level hie taij dudng ti sex sinh ra boss
        {
            milestoneOfBoss *= 2;

            Spawning(positonOfWorld.TakePositonOfWorld());// boosss 
        }
    }

    private void OnDisable()
    {
        if (list != null)
        {
            list.Clear();
        }
    }
    // Update is called once per frame
    void Update()
    {

        StartCoroutine(WaitHandleSpawnBoss());
    }

    private IEnumerator WaitHandleSpawnBoss()
    {
        // giả sử animation boss chết là 1.5s
        yield return new WaitForSeconds(1);
        HandleSpawnBoss();
    }


}
