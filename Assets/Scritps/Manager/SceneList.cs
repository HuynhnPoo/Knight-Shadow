using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneList:MonoBehaviour
{

    public static SceneList sceneInstance;
    public static SceneList SceneInstance { get => sceneInstance; }

    private void Awake()
    {
        if (sceneInstance != null && sceneInstance != this)
        {
            Destroy(this);
        }

        else 
        {
            sceneInstance = this;
        }
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
