using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour,IDameable
{
    private EnemyData enemyData;

    private float currentHeath;


    private void Awake()
    {
        if (enemyData == null) enemyData = Resources.Load<EnemyData>( "SO/Enemy/EnemyStrikeShort"); 
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
        Debug.Log("enemy bi chet");
    }
}
