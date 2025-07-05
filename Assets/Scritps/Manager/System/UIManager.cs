using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBase<UIManager>
{

    public SceneType currentScene = SceneType.NONE;
   [SerializeField] private GameObject menuPause;
    public GameObject MenuPause => menuPause;

   [SerializeField] private GameObject menuSetting;
    public GameObject MenuSetting => menuSetting;

    private GameObject menuGameOver;
    public GameObject MenuGameOver=> menuGameOver;

    private GameObject pnShop;
    public GameObject PnShop => pnShop; 
    
    private GameObject pnShopItem;
    public GameObject PnShopItem => pnShopItem;


    public static bool isNewGame=false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;   
    }

 

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

   
   private void OnSceneLoaded(Scene scene,LoadSceneMode sceneMode) 
    {
        if (scene.name != "BOOTSTRAP")
        {
            ReInitUIInScene();
        }
    }

    //danh sach cac scene
    public enum SceneType
    {
        NONE,
        MAINMENU,
        GAMEPLAY,
        LOADING
    }
    public void ReInitUIInScene()
    {
        menuPause = FindGameObjectByNameHide.FindGameObjectByName("Menu-Pause");
        menuSetting = FindGameObjectByNameHide.FindGameObjectByName("Menu-Setting");

        menuGameOver = FindGameObjectByNameHide.FindGameObjectByName("Menu-GameOver");

        pnShop= FindGameObjectByNameHide.FindGameObjectByName(TagInGame.pnShop);
        pnShopItem= FindGameObjectByNameHide.FindGameObjectByName(TagInGame.pnShopItem);
    }


    public AsyncOperation ChangeScene(SceneType scene)
    {
        return SceneManager.LoadSceneAsync(scene.ToString());
    }
}
