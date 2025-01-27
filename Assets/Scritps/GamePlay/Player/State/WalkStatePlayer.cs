using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStatePlayer : IState
{
    private PlayerPhysics player;
    private AnimationManager characterAni;
    private float horizontal=0;
    private float vertical=0;
    private bool isMove=false;
    Vector2 direction;
    public WalkStatePlayer(PlayerPhysics player,AnimationManager characterAni)
    {
       this.player = player;
        this.characterAni = characterAni;
    }
    public void Enter()
    {
        isMove = true;
        Debug.Log("enter walk state");
    }

    public void Execute()
    {
        if (player == null) return;
        if (isMove) {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction=new Vector2 (horizontal, vertical);
        player.Moving(horizontal, vertical);
        characterAni.MoveAni(isMove,direction);
        }
    }

    public void Exit()
    {
        isMove = false;
        direction = Vector2.zero;
        characterAni.MoveAni(isMove,direction);
        Debug.Log("exit walk state");
    }

}
