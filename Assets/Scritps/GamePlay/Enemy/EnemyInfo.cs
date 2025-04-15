using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class EnemyInfo : MonoBehaviour, IDameable, ICompoment
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private LoadAssetItem itemAsset;

    [SerializeField] private SpawnEnemy spawnEnemy;

    // data info enemy

    private string nameEnemy;
    public string NameEnemy =>nameEnemy;
    private int currentHeath, speed, dame;

    public int CurrentHeath { get => currentHeath; set => currentHeath = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Dame { get => dame; set => dame = value; }


    private float rangeAttack;

    public float RangeAttack { get => rangeAttack; }


    private float rapidAttack;
    public float RapidAttack { get => rapidAttack; }


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
        GetComponentsEnity();
    }

    public void GetComponentsEnity()
    {
        if (itemAsset == null && spawnEnemy == null)
        {
            itemAsset = GetComponentInParent<LoadAssetItem>();
            spawnEnemy = GetComponentInParent<SpawnEnemy>();
        }
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
            dame = enemyData.dame;// khia bao dame
            nameEnemy = enemyData.name;// ten quai vat

            rangeAttack = enemyData.rangeAttack;//  khi bao pham vi tan cong
            rapidAttack = enemyData.rapidAttack;//  khi bao pham vi tan cong
        }

    }

    public void TakeDame(int dame)
    {
        currentHeath -= dame;

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
        spawnEnemy.ReturnToPool(this.gameObject); // dua liaj vao pool
        DropItem();
    }


    // giet quai xong se hien roi ra item

    void DropItem()
    {

        System.Random random = new System.Random();

        switch (nameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":

                Debug.Log("hien thi ra radom " + random.NextDouble());
                if (random.NextDouble() <= 0.3)
                {
                    Debug.Log("thuc hien tanh cong spawn otem ddac biet" + random.NextDouble());
                    itemAsset.SpawnItem(0, this.transform);
                    itemAsset.SpawnItem(3, this.transform);
                }

                else
                {
                    itemAsset.SpawnItem(1, this.transform);
                    itemAsset.SpawnItem(4, this.transform);
                }
                break;

            case "Vampire":
            case "Plant":
                if (random.NextDouble() <= 0.5)
                {
                    Debug.Log("thuc hien tanh cong spawn otem ddac biet o ham danh xa" + random.NextDouble());
                    itemAsset.SpawnItem(0, this.transform);
                    itemAsset.SpawnItem(3, this.transform);

                }
                else
                {
                    itemAsset.SpawnItem(2, this.transform);
                    itemAsset.SpawnItem(5, this.transform);
                }
                break;

            default:
                Debug.LogWarning("Không dung quái");
                break;

        }
    }


}
