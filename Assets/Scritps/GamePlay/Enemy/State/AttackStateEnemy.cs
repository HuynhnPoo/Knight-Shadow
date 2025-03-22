using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackStateEnemy : IState
{
    private EnemyStateCrtl enemyStateCrtl;
    private int time = 3;
    private float coolDown = 0;
    private bool isAtack = false;

    public AttackStateEnemy(EnemyStateCrtl enemyStateCrtl)
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }

    public void Enter()
    {
        isAtack = true;
        coolDown = 0;
    }

    public void Execute()
    {
        if (isAtack)
        {
            coolDown -= Time.deltaTime;
            if (coolDown > 0) return;
            this.enemyStateCrtl.AttackPlayer();
            coolDown = time;
        }
    }

    public void Exit()
    {
        isAtack = false;
    }


}
