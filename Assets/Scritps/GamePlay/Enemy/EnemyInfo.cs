using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour,IDameable
{
    [SerializeField]private EnemyData enemyData;
    [SerializeField] private ObjectPoolList poolList;
    private float currentHeath;


    private void Awake()
    {
        if (enemyData == null) enemyData = Resources.Load<EnemyData>( "SO/Enemy/EnemyStrikeShort");
        
    }
    private void OnEnable()
    {
        if (poolList == null)
            poolList = GetComponentInParent<ObjectPoolList>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = enemyData.HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDame(int dame)
    {
        currentHeath -= dame;

        Debug.Log(currentHeath);
        if (currentHeath <= 0)
        { 
            DisableEnemy(); 
        }
    }

    void DisableEnemy()
    {

        Debug.Log("giet quais thanh cong");
       
       poolList.ReturnToPool(this.gameObject);  
    }

}
