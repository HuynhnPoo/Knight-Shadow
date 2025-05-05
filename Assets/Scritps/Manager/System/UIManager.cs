using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{

    public SceneType currentScene = SceneType.NONE;
    private GameObject menuPause;
    public GameObject MenuPause=> menuPause;

    private GameObject menuSetting;
    public GameObject MenuSetting=> menuSetting;

    public static bool isNewGame=false;
    private void OnEnable()
    {
        menuPause = FindGameObjectByNameHide.FindGameObjectByName("Menu-Pause");
        menuSetting = FindGameObjectByNameHide.FindGameObjectByName("Menu-Setting");
    }

    //danh sach cac scene
    public enum SceneType
    {
        NONE,
        MAINMENU,
        GAMEPLAY,
        LOADING
    }

    public AsyncOperation ChangeScene(SceneType scene)
    {
        return SceneManager.LoadSceneAsync(scene.ToString());
    }
}
