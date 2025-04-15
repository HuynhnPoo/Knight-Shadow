using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy : IState
{
    private EnemyStateCrtl enemyStateCrtl;
    //private int time = 3;
    private float coolDown = 0;
    private bool isAtack = false;

    public AttackStateEnemy(EnemyStateCrtl enemyStateCrtl)
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }

    public void Enter()
    {
        isAtack = true;
    }

    public void Execute()
    {
        if (isAtack)
        {
            coolDown -= Time.deltaTime;
          //  Debug.Log("hien thi 1" + coolDown);
            if (coolDown > 0) return;
            this.enemyStateCrtl.AttackPlayer();
            coolDown = enemyStateCrtl.GetRapidAttack();


           // Debug.Log("hien thi 2"+coolDown);
        }
    }

    public void Exit()
    {
        isAtack = false;
    }


}
