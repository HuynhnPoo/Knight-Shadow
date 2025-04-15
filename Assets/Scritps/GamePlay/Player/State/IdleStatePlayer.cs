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
        isIdle = true;
    }


    public void Execute()
    {
        if (characterInfo.Mana<threshHoldScore  && isIdle)
        {
            characterInfo.RegenMana(); // khi manna duoi  threshholdscore se thuc hien hoi phuc mana
        }
    }

    public void Exit()
    {
        isIdle = false;
    }

}
