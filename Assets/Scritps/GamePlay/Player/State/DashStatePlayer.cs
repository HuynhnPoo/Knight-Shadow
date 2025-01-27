using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStatePlayer : IState
{
    private PlayerPhysics player;
    float horizontal;
    float vertical;
    private float dashDuration = 0.5f;
    private float dashTimer = 0f;
    private bool isDashing = false;

    public DashStatePlayer(PlayerPhysics player,float horizontal,float vertical)
    { 
        this.player = player; 

        this.horizontal = horizontal;   
        this.vertical = vertical;
        
    }

    public void Enter()
    {
        Debug.Log("Bắt đầu dash");
        isDashing = true;
        dashTimer = dashDuration;
    }

    public void Execute()
    {
        if (isDashing)
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
