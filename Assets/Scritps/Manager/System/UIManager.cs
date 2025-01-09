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
    public void UINN()
    {
        Debug.Log("hien thi ra UINNI");
    }

    public enum SceneType
    {
        MAINMENU,
        GAMEPLAY,
        LOADING
    }

    public void ChangeScene(SceneType scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
