using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : ButtonBase
{
    protected override void OnClick()
    {

        UIManager.Instance.currentScene = UIManager.SceneType.MAINMENU;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);// chuyen sang scene loading6
       
    }

}
