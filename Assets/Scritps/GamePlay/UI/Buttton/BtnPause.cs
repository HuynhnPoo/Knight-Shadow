using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BtnPause : ButtonBase
{
    //  private static bool isPaused = false;
    //protected bool isPaused = false;
    private GameObject menuSetting, menuPause;
    protected override void OnClick()
    {
        Pausing();
    }

    //GameObject menuSetting;

    private void OnEnable()
    {
        menuPause = UIManager.Instance.MenuPause;
        menuSetting = UIManager.Instance.MenuSetting;
    }

    // bat menu pasue
    protected void Pausing()
    {
        if (!GameManager.Instance.IsPaused)
        {
            GameManager.Instance.IsPaused = true;
            menuPause.SetActive(true);
            if (menuSetting.activeSelf == true)
            {
                GameManager.Instance.IsPaused = true;
                menuPause.SetActive(false);
            }
            Time.timeScale = 0;

        }
        else
        {
            GameManager.Instance.IsPaused = false;
            menuPause.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
