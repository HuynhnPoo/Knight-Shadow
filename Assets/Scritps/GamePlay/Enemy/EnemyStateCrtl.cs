using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateCrtl : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    private StateManager stateManager;
   
    private int speed = 10;

    [Range(0.1f, 5f)] public float rangeAttack=3;
    [Range(0.1f, 10f)] public float rangeDetection=5;
    [SerializeField]private LayerMask playerLM;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position,playerPos.transform.position);


        if (distanceToPlayer <= rangeAttack)
        {
            stateManager.ChangeState(new AttackStateEnemy(this));
        }
        //if (distanceToPlayer < rangeDetection) { }
        else 
        { 
            stateManager.ChangeState(new ChaseStateEnemy(this));
        }
    }

    public void chaseToPlayer()
    {
        Vector3 direction = (playerPos.transform.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position,rangeAttack,playerLM);

        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("hirn thi"+player.name);

            player.GetComponentInChildren<CharacterInfo>().TakeDame(4);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,rangeAttack);
       
    }
}
