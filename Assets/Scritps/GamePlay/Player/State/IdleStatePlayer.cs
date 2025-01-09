using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStatePlayer : IState
{
    public void Enter()
    {
        Debug.Log("enter idle state ");
    }

    public void Exit()
    {
        Debug.Log("exit ilde state");
    }

    public void Execute()
    {
        Debug.Log("update ilde state");
    }
}
