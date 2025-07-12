using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private bool isPaused = false;
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private bool isGameOver = false;
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }


    private bool isWinGame = false;
    public bool IsWinGame { get => isWinGame; set => isWinGame = value; }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode loadScene)
    {
        if (scene.name == "Bootstrap")
        {
            return;
        }

         if (scene.name ==UIManager.SceneType.GAMEPLAY.ToString()) // Hoặc enum nếu bạn dùng SceneType
        {
            PlayerCrtlInit();
            currentLevel = 1;

        }
        else
        {
            playerCrtl = null; // Hoặc giữ nguyên nếu bạn cần lưu
           
        }
    }

    public void PlayerCrtlInit()
    {
        playerCrtl = GameObject.FindGameObjectWithTag(TagInGame.player).GetComponent<PlayerController>();
    }
    private void Start()
    {
        saveGold = PlayerPrefs.GetInt("GoldSave");
       /* saveGold = 10000000;

        PlayerPrefs.SetInt("GoldSave", saveGold);

        PlayerPrefs.Save();*/
    }
  
    public void GameOverWin()
    {
        //PlayerPrefs.SetInt("GoldSave", totalGold);
        if (this.isGameOver == true || this.isWinGame == true)
        {

            Time.timeScale = 0;
            UIManager.Instance.MenuGameOver.SetActive(true);
        }


    }


    //ham tang diem kinh nghiem
    public void AddExperice(int expericeScore)
    {
        currentExperice += expericeScore;
        if (currentExperice > maxExperice)
        {
            UpLevel();
        }

        else if (currentExperice == 20)
        {
            isWinGame = true;
            this.GameOverWin();
        }
    }

    //ham tang vang
    public void AddGold(int goldScore)
    {
        totalGold += goldScore;
        saveGold += goldScore;
       /* Debug.Log("hien thi total gold" + totalGold);
        Debug.Log("hien thi save Gold" + saveGold);*/
        PlayerPrefs.SetInt("GoldSave", saveGold);
        PlayerPrefs.Save();
    }

    void UpLevel()
    {
        currentExperice = 0;
        maxExperice *= 2;
        currentLevel++;

        SoundManager.Instance.PlaySfx(TagInGame.levelUp);
    }
}
