using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private PlayerController playerCrtl;
    public PlayerController PlayerCrtl { get { return playerCrtl; } }

   
    protected override void Awake()
    {
        base.Awake();
    }


    public void GameStart()
    { 
    }

    public void GameOver() 
    {
        Debug.Log("game over");
    }
}
