using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy : IState
{
    private EnemyStateCrtl enemyStateCrtl;
    private float coolDown = 0;
    private bool isAttack = false;
    private float initialDelay = 0.5f; // Delay ban đầu khi vào trạng thái Attack

    public AttackStateEnemy(EnemyStateCrtl enemyStateCrtl)
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }

    public void Enter()
    {
        isAttack = true;
        // Thiết lập delay ban đầu để tránh tấn công ngay lập tức
        coolDown = initialDelay;
    }

    public void Execute()
    {
        if (isAttack)
        {
            coolDown -= Time.deltaTime;

            if (coolDown <= 0)
            {
                this.enemyStateCrtl.AttackPlayer();
                coolDown = enemyStateCrtl.GetRapidAttack();
            }
        }
    }

    public void Exit()
    {
        isAttack = false;
    }
}