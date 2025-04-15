using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnExit : ButtonBase
{
  //  [SerializeField] private GameObject menuPause;
    protected override void OnClick() => ExittingGame();
   

    void ExittingGame()
    {
        Time.timeScale = 1;
        UIManager.Instance.currentScene = UIManager.SceneType.GAMEPLAY;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);
    }
}
   