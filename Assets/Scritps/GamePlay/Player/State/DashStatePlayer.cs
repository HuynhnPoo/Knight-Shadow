using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStatePlayer : IState
{
    private PlayerPhysics player;
    private CharacterInfo character;
    float horizontal;
    float vertical;
    private float dashDuration = 0.5f;
    private float dashTimer = 0f;
    private bool isDashing = false;

    public DashStatePlayer(PlayerPhysics player,CharacterInfo character,float horizontal,float vertical)
    { 
        this.player = player; 
        this.character = character;
        this.horizontal = horizontal;   
        this.vertical = vertical;
        
    }

    public void Enter()
    {
        Debug.Log("Bắt đầu dash");
       this.character.ReductionMana(50);
        isDashing = true;
        dashTimer = dashDuration;
    }

    public void Execute()
    {
        if (isDashing && this.character.Mana>0)
        {
            if (dashTimer > 0)
            {
                player.Dashing(horizontal,vertical);

                dashTimer -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
    }

    public void Exit()
    {
        Debug.Log("Kết thúc dash");
        isDashing = false;
        dashTimer = 0f;


    }

    
}
