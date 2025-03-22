using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private PlayerController playerCrtl;
    public PlayerController PlayerCrtl { get { return playerCrtl; } }

    int totalGold = 0;
    int titalExperice = 0;
   
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

    public void AddScore()
    {
        
    } 
    public void AddGold()
    {
        
    }
}
