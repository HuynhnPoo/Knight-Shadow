using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{

    protected override void Awake()
    {
        base.Awake();
    }

    //danh sach cac scene
    public enum SceneType
    {
        MAINMENU,
        GAMEPLAY,
        LOADING
    }

    //ham thuc hien thya doi scene
    public void ChangeScene(SceneType scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
