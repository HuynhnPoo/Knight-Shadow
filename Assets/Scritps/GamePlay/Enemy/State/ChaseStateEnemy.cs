using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseStateEnemy : IState
{

    [SerializeField] private EnemyStateCrtl enemyMove;

    public ChaseStateEnemy(EnemyStateCrtl enemyMove)
    {
        this.enemyMove = enemyMove;
    }

    public void Enter()
    {

       // Debug.Log("enter enenmy");
    }

    public void Execute()
    {
        enemyMove.chaseToPlayer();
    }

    public void Exit()
    {
     
       // Debug.Log("exit enenmy");
    }
}
