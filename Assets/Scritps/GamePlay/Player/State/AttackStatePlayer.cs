using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatePlayer :IState
{
    private PlayerController playerController;
    int cooldown = 2;
    float timer;
    public AttackStatePlayer(PlayerController playerController)
    {

    
     this.playerController = playerController;
    }

    public void Enter()
    {
        timer = 0;
    }

    public void Execute()
    {
        timer -= Time.deltaTime;
        if (timer >= 0) return;
        this.playerController.Attack();
        timer = cooldown;   
    }

    public void Exit()
    {
       // Debug.Log("thuc hien eixt attack");
    }

   
}
