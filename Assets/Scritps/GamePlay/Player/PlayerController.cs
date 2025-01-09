using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]private StateManager stateManager;
    [HideInInspector]public CharacterInfo characterInfo;
    int speed = 20;
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
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            stateManager.ChangeState(new WalkStatePlayer(characterInfo));
        }
        else
        {
            stateManager.ChangeState(new IdleStatePlayer());
        }
    }

    //ham thuc hien di chuyen
    public void Moving(float directionX, float directionY)
    {
        Vector3 playerDirection = new Vector3(directionX,directionY);
        transform.Translate(playerDirection * speed * Time.deltaTime);
    }

}
 