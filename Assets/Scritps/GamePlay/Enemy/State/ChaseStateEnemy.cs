using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseStateEnemy : IState
{

    [SerializeField] private EnemyMove enemyMove;

    public ChaseStateEnemy(EnemyMove enemyMove)
    {
        this.enemyMove = enemyMove;
    }

    public void Enter()
    {
        // throw new System.NotImplementedException();

        Debug.Log("enter enenmy");
    }

    public void Execute()
    {
        enemyMove.chaseToPlayer();
    }

    public void Exit()
    {
     
        Debug.Log("exit enenmy");
    }
}
