using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCrtl : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField]private AnimationEnity enemyAni;
    private EnemyAttack enemyAttack;
    private EnemyInfo enemyInfo;
    private StateManager stateManager;
   
//private int speed = 10;

  //  [Range(0.1f, 5f)] public float rangeAttack=3;
    Vector3 direction;
    public Vector3 DirectionEnemy { get => direction; set => direction = value; }
    private void OnEnable()
    {
       GetComponentsEnity();
    }
    void GetComponentsEnity() 
    {
        playerPos = GameObject.FindGameObjectWithTag(TagInGame.player).transform;
        enemyInfo = GetComponent<EnemyInfo>();
        enemyAttack= GetComponentInParent<EnemyAttack>();
        stateManager = GetComponent<StateManager>();
        enemyAni = GetComponent<AnimationEnity>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position,playerPos.transform.position);
        if (distanceToPlayer <= enemyInfo.RangeAttack)
        {
           // Debug.Log("hien thi distance"+ distanceToPlayer);
            stateManager.ChangeState(new AttackStateEnemy(this));
        }
        //if (distanceToPlayer < rangeDetection) { }
        else 
        { 
            stateManager.ChangeState(new ChaseStateEnemy(this,enemyAni));
        }
    }

  

    public void chaseToPlayer()
    {
        direction = DirectionOfEnemy();

    //    Debug.Log("hien thi direction" + direction.x+"hgfgfg"+ direction.y);
        transform.Translate(direction * enemyInfo.Speed * Time.deltaTime);
    }

    Vector2 DirectionOfEnemy()
    {
        return (playerPos.transform.position - transform.position).normalized;
    }

    public void AttackPlayer()
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
                enemyAttack.RangedAttackPlayer(this.transform.position, DirectionOfEnemy(),this);
                break;

            default:
                Debug.LogError("hien thi loi ");
                break;
        }
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
