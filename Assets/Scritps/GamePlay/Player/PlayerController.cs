using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private StateManager stateManager;
    [SerializeField] private CharacterInfo characterInfo;

    int speed = 20;

    [Range(0.1f, 5f)] public float rangeAttack;
    [SerializeField] private LayerMask enemy;

    // Start is called before the first frame update
    void Start()
    {
        this.stateManager = GetComponent<StateManager>();
        this.characterInfo = GetComponentInChildren<CharacterInfo>();
        stateManager.ChangeState(new IdleStatePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerState();
    }

    //ham kie tra va thuc cac trang thai nhan vat
    public void PlayerState()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

         if (Input.GetKeyDown(KeyCode.U) && (horizontal != 0 || vertical != 0))
        {
                stateManager.ChangeState(new DashStatePlayer(this,horizontal,vertical));
        }
        else if (horizontal != 0 || vertical != 0)
        {
            stateManager.ChangeState(new WalkStatePlayer(characterInfo));
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            stateManager.ChangeState(new AttackStatePlayer(this));
        }
        else
        {
            stateManager.ChangeState(new IdleStatePlayer());
        }
    }

    //ham thuc hien di chuyen
    public void Moving(float directionX, float directionY)
    {
        Vector3 playerDirection = new Vector3(directionX, directionY);
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }
    public void Dash(float directionX, float directionY)
    {
        Vector2 dashDirection = new Vector2(directionX, directionY).normalized;

        transform.Translate(dashDirection * 2);
    }

    public void Attack()
    {

        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(this.transform.position, rangeAttack, enemy);

        foreach (Collider2D enemies in hitEnemis)
        {
            Debug.LogWarning("hien thi enemy" + enemies.name);
            enemies.GetComponent<EnemyInfo>().TakeDame(characterInfo.Dame);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, rangeAttack);
    }
}
