using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{

    public SceneType currentScene = SceneType.NONE;

    protected override void Awake()
    {
        base.Awake();
    }

    //danh sach cac scene
    public enum SceneType
    {
        NONE,
        MAINMENU,
        GAMEPLAY,
        LOADING
    }

    //ham thuc hien thya doi scene
   /* public void ChangeScene(SceneType scene)
    {
       
         SceneManager.LoadScene(scene.ToString());
        
    }*/

    public AsyncOperation ChangeScene(SceneType scene)
    {
        return SceneManager.LoadSceneAsync(scene.ToString());
    }
}
