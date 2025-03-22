using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : ButtonBase
{
    protected override void OnClick() => ExittingGame();
   

    void ExittingGame()
    {
        UIManager.Instance.currentScene = UIManager.SceneType.GAMEPLAY;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);
    }
}
