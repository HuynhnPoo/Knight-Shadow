using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkillStateEnemy : IState
{
    private EnemyStateCrtl enemyStateCrtl;
    private StateManager stateManager;
    private BossAttack enemyAttack;
    // private Transform skillBoss;
    private bool isAttackSkillFinshed = true;

    // bo dem thoi gian
    float skillDuration = 2;
    float elapsedTime = 0;
    float damageInterval = 0.5f;

    public AttackSkillStateEnemy(EnemyStateCrtl enemyStateCrtl, StateManager stateManager, EnemyAttack enemyAttack)
    {
        this.enemyStateCrtl = enemyStateCrtl;
        this.stateManager = stateManager;
        this.enemyAttack = enemyAttack as BossAttack;


        
        //this.skillBoss =enemyStateCrtl.SkillBoss;
    }

    public void Enter()
    {
        isAttackSkillFinshed = false;

        Debug.Log("hien thi ra 111"+ this.enemyStateCrtl + this.stateManager + this.enemyAttack); // khono loi
        // Thiết lập delay ban đầu để tránh tấn công ngay lập tức
        enemyStateCrtl.StartCoroutine(ExecuteSkill());

    }

    public void Execute()
    {
        if (isAttackSkillFinshed)
        {
            enemyStateCrtl.ChangeStateOfEnemy();
        }
    }

    public void Exit() { }

    IEnumerator ExecuteSkill()
    {
        Debug.Log("thuc hien hàm skill");
        yield return enemyAttack.ExecuteSkillOfBoss(enemyStateCrtl, skillDuration, damageInterval, elapsedTime);
        isAttackSkillFinshed = true;
    }
}