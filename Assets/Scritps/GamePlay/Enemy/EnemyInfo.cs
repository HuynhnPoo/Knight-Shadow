using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class EnemyInfo : MonoBehaviour, IDameable
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private ObjectPoolList poolList;
    [SerializeField] private LoadAssetItem itemAsset;

    // data info enemy

    private string nameEnemy;
    private int currentHeath, speed, dame;

    public int CurrentHeath { get => currentHeath; set => currentHeath = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Dame { get => dame; set => dame = value; }


    private float rangeAttack;

    public float RangeAttack { get => rangeAttack; }


    private void Awake()
    {
        if (enemyData == null)
        {
            string enemyName = gameObject.name;
            enemyName = enemyName.Split('(')[0].Trim();
            string resourcePath = "SO/Enemy/" + enemyName;
            enemyData = Resources.Load<EnemyData>(resourcePath);
        }
    }


    private void OnEnable()
    {
        if (itemAsset == null) itemAsset = GetComponentInParent<LoadAssetItem>();
        if (poolList == null) poolList = GetComponentInParent<ObjectPoolList>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }


    void InitData()
    {
        if (enemyData != null)
        {
            currentHeath = enemyData.HP;
            speed = enemyData.Speed;
            dame = enemyData.dame;
            nameEnemy = enemyData.name;

            rangeAttack = enemyData.rangeAttack;
        }

    }

    public void TakeDame(int dame)
    {
        currentHeath -= dame;

        Debug.Log(currentHeath);
        if (currentHeath <= 0)
        {
            DisableEnemy();

            //itemAsset.SpawnItem();
        }
    }

    // thuc hien chuyen cac enemy chet vao pool
    void DisableEnemy()
    {
        Debug.Log("giet quais thanh cong");
        poolList.ReturnToPool(this.gameObject);
        DropItem();
    }


    void DropItem()
    {
        switch (nameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":
                Debug.Log("hien thi " + gameObject.name);

                itemAsset.SpawnItem(0,this.transform);
                itemAsset.SpawnItem(4, this.transform);
                break;

            case "Vampire":
            case "Plant":
                itemAsset.SpawnItem(2, this.transform);
                itemAsset.SpawnItem(5, this.transform);
                break;

        }
    }

}
