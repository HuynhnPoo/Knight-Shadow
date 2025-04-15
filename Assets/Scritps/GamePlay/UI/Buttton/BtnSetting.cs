using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : ButtonBase
{
  //  private static bool isActiveSetting = false;
    private GameObject menuSetting, menuPause;
    protected override void OnClick() => SettingActive();

    private void OnEnable()
    {

    }

    void SettingActive()
    {
        GameObject menuPause = UIManager.Instance.MenuPause;
        GameObject menuSetting = UIManager.Instance.MenuSetting;

        if (!GameManager.Instance.IsPaused)
        {
            GameManager.Instance.IsPaused = true;
            menuSetting.SetActive(true);

            if (menuPause.activeSelf == true)
            {
                GameManager.Instance.IsPaused = true;
                menuPause.SetActive(false);
            }
        }
        else
        {
            GameManager.Instance.IsPaused = false;
            menuSetting.SetActive(false);
        }
    }
}
