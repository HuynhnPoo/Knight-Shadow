using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class EnemyInfo : MonoBehaviour, IDameable, ICompoment
{
    [SerializeField] private EnemyData enemyData;


    [SerializeField] private SpawnEnemy spawnEnemy;

    private DeathEnemy deathEnemy;

    // data info enemy

    private string nameEnemy;
    public string NameEnemy => nameEnemy;
    private int currentHeath, speed, dame;

    public int CurrentHeath { get => currentHeath; set => currentHeath = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Dame { get => dame; set => dame = value; }

    private float rangeAttack;
    public float RangeAttack { get => rangeAttack; }
    private float rapidAttack;
    public float RapidAttack { get => rapidAttack; }

    private bool isBoss;
    public bool IsBoss => isBoss;

    private int numberTimeAtk;
    public int NumberTimeAtk => numberTimeAtk;
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
        if (spawnEnemy == null && deathEnemy == null)
        {
            spawnEnemy = GetComponentInParent<SpawnEnemy>();
            deathEnemy = GetComponent<DeathEnemy>();
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
            isBoss = enemyData.isBoss;

            rangeAttack = enemyData.rangeAttack;//  khi bao pham vi tan cong
            rapidAttack = enemyData.rapidAttack;//  khi bao toc do tan cong

            numberTimeAtk = enemyData.numberTimesAtk;
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
        if (IsBoss) Destroy(this.gameObject); 
        else  spawnEnemy.ReturnToPool(this.gameObject); // dua liaj vao pool
        deathEnemy.DropItem();
    }

}
