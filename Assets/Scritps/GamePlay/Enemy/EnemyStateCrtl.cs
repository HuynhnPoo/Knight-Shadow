using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCrtl : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField]private AnimationEnity enemyAni;
    private EnemyInfo enemyInfo;
    private StateManager stateManager;
   
//private int speed = 10;

  //  [Range(0.1f, 5f)] public float rangeAttack=3;
    [SerializeField]private LayerMask playerLM;
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
        stateManager = GetComponent<StateManager>();
        enemyAni = GetComponent<AnimationEnity>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
         direction = (playerPos.transform.position - transform.position).normalized;

    //    Debug.Log("hien thi direction" + direction.x+"hgfgfg"+ direction.y);
        transform.Translate(direction * enemyInfo.Speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position,enemyInfo.RangeAttack,playerLM);

        foreach (Collider2D player in hitPlayers)
        {
           // Debug.Log("hirn thi"+player.name);

            player.GetComponentInChildren<CharacterInfo>().TakeDame(enemyInfo.Dame);
        }
    }

   /* private void OnDrawGizmosSelected()
    {
     //   Gizmos.DrawWireSphere(transform.position,enemyInfo.RangeAttack); 
    }*/
}
