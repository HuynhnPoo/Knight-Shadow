using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.Save();

        newGameButton.SetActive(true);
        UIManager.Instance.currentScene = UIManager.SceneType.MAINMENU;
        UIManager.Instance.ChangeScene(UIManager.SceneType.LOADING);// chuyen sang scene loading6
    }


}
