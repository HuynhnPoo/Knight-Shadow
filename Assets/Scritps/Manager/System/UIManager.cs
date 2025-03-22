using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{

    public SceneType currentScene = SceneType.NONE;

    [SerializeField]private GameObject menuSetting;

    public GameObject MenuSetting { get => menuSetting; }

    [SerializeField]private GameObject menuPause;

    public GameObject MenuPause { get => menuPause; }


    protected override void Awake()
    {
        base.Awake();

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
