using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline;
using UnityEngine;

public class EnemyInfo : MonoBehaviour, IDameable,ICompoment
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private LoadAssetItem itemAsset;

    [SerializeField] private SpawnEnemy spawnEnemy;

    // data info enemy

    private string nameEnemy;
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
        spawnEnemy.ReturnToPool(this.gameObject); // dua liaj vao pool
        DropItem();
    }


    // giet quai xong se hien roi ra item

    void DropItem()
    {
        switch (nameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":

                itemAsset.SpawnItem(0, this.transform);
                itemAsset.SpawnItem(1, this.transform);
                break;

            case "Vampire":
            case "Plant":
                itemAsset.SpawnItem(2, this.transform);
                itemAsset.SpawnItem(5, this.transform);
                break;

            default:

                Debug.LogWarning("Không dung quái");
                break;

        }
    }

    
}
