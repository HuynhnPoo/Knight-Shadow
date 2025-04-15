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

    int saveGold = 0;

    public int SaveGold { get => saveGold; set => saveGold = value; }



    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;
   

    private bool isPaused=false;
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private bool isGameOver = false;
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    protected override void Awake()
    {
        base.Awake();

        saveGold = PlayerPrefs.GetInt("GoldSave");

    }


    public void GameStart()
    { 

    }

    public void GameOver() 
    {
        //PlayerPrefs.SetInt("GoldSave", totalGold);
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
        saveGold += totalGold;
        Debug.Log("hien thi save Gold"+ saveGold);
        PlayerPrefs.SetInt("GoldSave", saveGold);
    }

    void UpLevel()
    {
        currentExperice = 0;
        maxExperice *= 2;
        currentLevel++;
    }
}
