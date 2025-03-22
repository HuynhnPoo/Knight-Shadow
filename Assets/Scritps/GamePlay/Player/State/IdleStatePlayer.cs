using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStatePlayer : IState
{

    private int threshholdScore = 10;

    private bool isIdle = false;

   private  CharacterInfo characterInfo;
   

    public IdleStatePlayer(CharacterInfo characterInfo)
    { 
        this.characterInfo = characterInfo; 
    }


    public void Enter()
    {
        isIdle = true;
    }


    public void Execute()
    {
        if (characterInfo.Mana<threshholdScore  && isIdle)
        {
            characterInfo.RegenMana();
        }
    }

    public void Exit()
    {
        isIdle = false;
    }

}
