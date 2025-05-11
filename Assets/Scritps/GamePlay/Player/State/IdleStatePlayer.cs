using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStatePlayer : IState
{

    private int threshHoldScore = 10;

    private bool isIdle = false;

   private  CharacterInfo characterInfo;
   

    public IdleStatePlayer(CharacterInfo characterInfo)
    { 
        this.characterInfo = characterInfo; 
    }


    public void Enter()
    {
        Debug.Log("thuc hien enter idle");
        isIdle = true;
    }


    public void Execute()
    {
        Debug.Log("thuc hien enter execute");
        if (characterInfo.Mana<threshHoldScore  && isIdle)
        {
            characterInfo.RegenMana(); // khi manna duoi  threshholdscore se thuc hien hoi phuc mana
        }
    }

    public void Exit()
    {
        Debug.Log("thuc hien enter exit");
        isIdle = false;
    }

}
