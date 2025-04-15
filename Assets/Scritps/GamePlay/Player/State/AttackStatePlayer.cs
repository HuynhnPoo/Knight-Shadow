using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatePlayer :IState
{
    private Weapon weapon;
    int cooldown = 2;
    float timer=0;
    public AttackStatePlayer(Weapon weapon)
    {
     this.weapon = weapon;
    }

    public void Enter()
    {
       
    }

    public void Execute()
    {
        timer -= Time.deltaTime;
        if (timer > 0) return;
        this.weapon.Attacking();
        timer = cooldown;
    }

    public void Exit()
    {
       
    }

   
}
