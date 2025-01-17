using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy : IState
{
    private EnemyStateCrtl enemyStateCrtl;

    public AttackStateEnemy(EnemyStateCrtl enemyStateCrtl) 
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }  

    public void Enter()
    {
        Debug.Log("hien thi bat ddau state");
    }

    public void Execute()
    {
        Debug.Log("hien thi dang thuc hien state");
        this.enemyStateCrtl.AttackPlayer();
    }

    public void Exit()
    {
        Debug.Log("hien thi ket thuc state");
    }

    
}
