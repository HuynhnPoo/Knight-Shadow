using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : ButtonBase
{
    [SerializeField] private GameObject newGameButton;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("NewGame", 1) == 0)
        {
            newGameButton.SetActive(true);
        }
        else
        {
            newGameButton.SetActive(false);
        }
    }

    protected override void OnClick()
    {
        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.Save();

        newGameButton.SetActive(true);
        UIManager.Instance.currentScene = UIManager.SceneType.MAINMENU;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);// chuyen sang scene loading6
    }


}
