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
    private int milestoneOfBoss = 2;

    private void Awake()
    {
        positonOfWorld = new PositonOfWorld();
        GameManagerAssetsLoad.LoadingGameAsset(itemAssets, list, this, onLoadBoss); // load các item bang addressable
    }

    public void onLoadBoss()
    {
        hoderObject = transform.Find("HolderBoss");
        enemyPrefabs = list.ToArray();


        pool = new ObjectPool<List<GameObject>>(enemyPrefabs, size, hoderObject);

    }



    private void OnEnable()
    {
        size = 5;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void HandleSpawnBoss()
    {
        int curentLevel = GameManager.Instance.CurrentLevel;
        if (curentLevel == milestoneOfBoss && positonOfWorld != null)
        {
            milestoneOfBoss *= 2;
            Spawning(positonOfWorld.TakePositonOfWorld());
        }
    }


    // Update is called once per frame
    void Update()
    {

        HandleSpawnBoss();


    }
}
