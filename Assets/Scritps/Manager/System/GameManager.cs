using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private PlayerController playerCrtl;
    public PlayerController PlayerCrtl { get { return playerCrtl; } }


    private int maxExperice = 100;
    public int MaxExperice => maxExperice;
    

    private int currentExperice = 0;
    public int CurrentExperice { get { return currentExperice; } }

    int totalGold = 0;
    public int TotalGold { get => totalGold; set => totalGold = value; }
    
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;
   
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


    //ham tang diem kinh nghiem
    public void AddExperice(int expericeScore)
    {

        currentExperice += expericeScore;
        if(currentExperice > maxExperice)
        {
            UpLevel(); 
        }
    }

    //ham tang vang
    public void AddGold(int goldScore)
    {
        totalGold += goldScore;
       // Debug.Log("hien thi vang " + totalGold);
    }

    void UpLevel()
    {
        currentExperice = 0;
        maxExperice *= 2;
        currentLevel++;
    }
}
