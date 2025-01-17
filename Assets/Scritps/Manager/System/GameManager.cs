using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
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
