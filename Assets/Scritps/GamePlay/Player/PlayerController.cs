using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private StateManager stateManager;
    [SerializeField] private CharacterInfo characterInfo;
    [SerializeField] private PlayerPhysics playerPhysics;
    [SerializeField] private AnimationManager characterAni;
    [Range(0.1f, 5f)] public float rangeAttack;
    [SerializeField] private LayerMask enemy;

    // Start is called before the first frame update
    void Start()
    {
        this.stateManager = GetComponent<StateManager>();
        this.playerPhysics = GetComponent<PlayerPhysics>();
        this.characterInfo = GetComponentInChildren<CharacterInfo>();
        this.characterAni = GetComponentInChildren<AnimationManager>();
        this.stateManager.ChangeState(new IdleStatePlayer());
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
            stateManager.ChangeState(new DashStatePlayer(playerPhysics, horizontal, vertical));
        }
        else if (horizontal != 0 || vertical != 0)
        {
            stateManager.ChangeState(new WalkStatePlayer(playerPhysics,characterAni));
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            stateManager.ChangeState(new AttackStatePlayer(this));
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            UIManager.Instance.ChangeScene(UIManager.SceneType.MAINMENU);
        }
        else
        {
            stateManager.ChangeState(new IdleStatePlayer());
        }
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
