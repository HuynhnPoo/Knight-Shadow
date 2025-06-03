using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseStateEnemy : IState
{

    private EnemyStateCrtl enemyMove;
    private AnimationEnity enemyAni;

    bool isMove = false;
    public ChaseStateEnemy(EnemyStateCrtl enemyMove, AnimationEnity enemyAni)
    {
        this.enemyMove = enemyMove;

        this.enemyAni = enemyAni;
    }

    public void Enter()
    {

        isMove = true;
        // Debug.Log("enter enenmy");
    }

    public void Execute()
    {
        if (isMove && enemyAni != null)
        {
            enemyMove.chaseToPlayer();
            enemyAni.MoveAni(isMove, enemyMove.DirectionEnemy);
        }

       
    }

    public void Exit()
    {
        isMove = false;
    }
}
