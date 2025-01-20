using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStatePlayer : IState
{
    private PlayerController PlayerController;
    float horizontal;
    float vertical;
    private float dashSpeed = 6f;
    private float dashDuration = 0.2f;
    private float dashTimer = 0f;
    private bool isDashing = false;

    public DashStatePlayer(PlayerController playerController,float horizontal,float vertical)
    { 
        this.PlayerController = playerController; 

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
                //// Chuẩn hóa vector để dash có tốc độ đồng nhất
                //Vector2 direction = new Vector2(horizontal, vertical).normalized;

                // Thực hiện dash
                PlayerController.Dash(horizontal,vertical);

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
