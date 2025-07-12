using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRestart : ButtonBase
{

    GameObject menuPause;
    protected override void OnClick()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        Time.timeScale = 1;

        GameManager.Instance.IsPaused = false;
        GameManager.Instance.IsGameOver = false;

        menuPause = UIManager.Instance.MenuPause;
        menuPause.SetActive(false);
        UIManager.Instance.ChangeScene(UIManager.SceneType.GAMEPLAY);
    }
}
