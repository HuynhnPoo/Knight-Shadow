using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRestart : ButtonBase
{

    GameObject menuPause;
    protected override void OnClick()
    {
        Time.timeScale = 1;

        menuPause = UIManager.Instance.MenuPause;
        menuPause.SetActive(false);
        UIManager.Instance.ChangeScene(UIManager.SceneType.GAMEPLAY);
    }
}
