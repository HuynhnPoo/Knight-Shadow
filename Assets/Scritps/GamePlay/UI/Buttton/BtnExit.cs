using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class BtnExit : ButtonBase
{
  //  [SerializeField] private GameObject menuPause;
    protected override void OnClick() => ExittingGame();
   

    void ExittingGame()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        Time.timeScale = 1;
        GameManager.Instance.IsPaused = false;
        GameManager.Instance.IsGameOver = false;

       
        UIManager.Instance.currentScene = UIManager.SceneType.GAMEPLAY;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);


    }
}
   