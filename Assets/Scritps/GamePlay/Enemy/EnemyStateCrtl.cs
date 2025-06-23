using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCrtl : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private AnimationEnity enemyAni;
    [SerializeField] private EnemyAttack enemyAttack;
    private EnemyInfo enemyInfo;
    private StateManager stateManager;

   [SerializeField] private Transform skillBoss;

    Vector3 direction;

    bool isUseSkill = false;
    int normalAttackCount;

    public Vector3 DirectionEnemy { get => direction; set => direction = value; }
    private void OnEnable()
    {
        GetComponentsEnity();
    }

    void GetComponentsEnity()
    {
        playerPos = GameObject.FindGameObjectWithTag(TagInGame.player).transform;
        enemyInfo = GetComponent<EnemyInfo>();
        enemyAttack = GetComponentInParent<EnemyAttack>();
        stateManager = GetComponent<StateManager>();
        enemyAni = GetComponent<AnimationEnity>();

        SetupBossProperty();

    }

    private void Start()
    {
        if (skillBoss ==null) SetupBossProperty();
    }

    void SetupBossProperty()
    {
        if (enemyInfo.IsBoss)
        {

            foreach (Transform child in this.transform)
            {

                if (child.gameObject.name == "skill")
                    skillBoss = child;
            }

            normalAttackCount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.transform.position);
        if (distanceToPlayer <= enemyInfo.RangeAttack)
        {
            stateManager.ChangeState(new AttackStateEnemy(this));
        }
        else
        {
            stateManager.ChangeState(new ChaseStateEnemy(this, enemyAni));
        }
    }

    public void chaseToPlayer()
    {
        direction = DirectionOfEnemy();
        transform.Translate(direction * enemyInfo.Speed * Time.deltaTime);
    }

    Vector2 DirectionOfEnemy()
    {
        return (playerPos.transform.position - transform.position).normalized;
    }

    public void AttackPlayer()
    {
        if (enemyInfo.IsBoss)
        {
            HandleBossAttack();
        }
        else
        {
            HandleNormalEnemyAttack();
        }
    }

    public void HandleNormalEnemyAttack()
    {
        switch (enemyInfo.NameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":
                enemyAttack.MeleeAttackPlayer(enemyInfo.Dame, enemyInfo.RangeAttack, this.transform.position);
                break;

            case "Plant":
            case "Vampire":
                enemyAttack.RangedAttackPlayer(this.transform.position, DirectionOfEnemy(), this);
                break;

            default:
                Debug.LogError("hien thi loi ");
                break;
        }
    }

    // quan lis trang thais tan con cua boss
    private void HandleBossAttack()
    {

        Debug.Log("hien thi ra thoi gian danh " + normalAttackCount);
        if (isUseSkill) return ;

        enemyAni.AttackBossAni();
        if (normalAttackCount >= enemyInfo.NumberTimeAtk)
        {
            // thuc hien skill cua boss

            isUseSkill = false;
            StartCoroutine(enemyAttack.ExecuteSkillOfBoss(isUseSkill,normalAttackCount,skillBoss));
            normalAttackCount = 0;
          
        }

        else
        {
            Debug.Log("hien thi ra thu hien dnah thuong lannnnn");
            switch (enemyInfo.NameEnemy)
            {
                case "Lucifer_Boss": 
                case "Sekeleton-Boss":
                    enemyAttack.MeleeAttackPlayer(enemyInfo.Dame, enemyInfo.RangeAttack, this.transform.position);
                    break;
                case "Rider-Boss":
                    enemyAttack.RangedAttackPlayer(this.transform.position,DirectionOfEnemy(),this);
                    break;
                default:
                    // Mặc định cho boss nếu không có trường hợp cụ thể, dùng melee
                    // enemyAttack.RangedAttackPlayer(this.transform.position, DirectionOfEnemy(), this);
                    Debug.LogWarning("hien ten cua enemy sai");

                    break;
            }
            normalAttackCount++;

        }


    }

    public bool GetIsBoss()
    {
        return enemyInfo.IsBoss;
    }
    public float GetRapidAttack()
    {
        return enemyInfo.RapidAttack;   
    }

    public void GetObjectToPool(GameObject obj)
    {
        enemyAttack.ReturnToPoolBulletE(obj);
    }

    public int GetDameOfEnemy()
    {
        return enemyInfo.Dame;
    }
}
