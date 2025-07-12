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
    public  Transform SkillBoss => skillBoss;


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
           
            foreach (Transform child in this.transform)// duyet qua cac con của để tìm game object có tên là skill
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

      
        ChangeStateOfEnemy();
    }


    //ham chuyen state cua enemy
    public void ChangeStateOfEnemy()
    {
        float distanceToPlayer = GetDistanceEnemy();
        if (distanceToPlayer <= enemyInfo.RangeAttack)
        {
            stateManager.ChangeState(new AttackStateEnemy(this));
        }
        else
        {
            stateManager.ChangeState(new ChaseStateEnemy(this, enemyAni));
        }
    }

    public float GetDistanceEnemy()
    {
        return Vector2.Distance(transform.position, playerPos.transform.position);
    }


    private void OnDrawGizmosSelected()
    {
        if (enemyInfo == null) return;


        // Vẽ vùng skill nếu là boss
        if (enemyInfo.IsBoss)
        {
            Gizmos.color = Color.red; // Màu khác để phân biệt
            Gizmos.DrawWireSphere(transform.position, enemyInfo.RangeAttack);
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

        if (isUseSkill) return;

        enemyAni.AttackBossAni();
        if (normalAttackCount >= enemyInfo.NumberTimeAtk)
        {
            // thuc hien skill cua boss
            stateManager.ChangeState(new AttackSkillStateEnemy(this,this.stateManager,this.enemyAttack));
            normalAttackCount = 0;
        }

        else
        {
            switch (enemyInfo.NameEnemy)
            {
               
                case "Lucifer_Boss": 
                case "Sekeleton_Boss":
                    enemyAttack.MeleeAttackPlayer(enemyInfo.Dame, enemyInfo.RangeAttack, this.transform.position);
                    break;
                case "Rider_Boss":
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
    public string GetNameEnemy()
    {
        return enemyInfo.NameEnemy;
    }
    public float GetRapidAttack()
    {
        return enemyInfo.RapidAttack;   
    } 
    public float GetRangedAttack()
    {
        return enemyInfo.RangeAttack; 
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
