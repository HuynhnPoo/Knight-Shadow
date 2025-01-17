using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStatePlayer : IState
{
    private CharacterInfo characterInfo;
    private float horizontal=0;
    private float vertical=0;

    PlayerController playerController;
    public WalkStatePlayer(CharacterInfo characterInfo)
    {
       this.characterInfo = characterInfo;
    }
    public void Enter()
    {
        Debug.Log("enter walk state");
    }

    public void Execute()
    {
        if (characterInfo == null) return;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        characterInfo.Moving(horizontal, vertical);
    }

    public void Exit()
    {
        Debug.Log("exit walk state");
    }

}
