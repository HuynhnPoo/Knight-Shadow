using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : ButtonBase
{
    private static bool isActiveSetting = false;
    private GameObject menuSetting;

     private GameObject menuPasue;

    protected override void Start()
    {
        base.Start();
        menuSetting = UIManager.Instance.MenuSetting.gameObject;

        menuPasue = UIManager.Instance.MenuPause.gameObject;
    }
    protected override void OnClick() => SettingActive();

    void SettingActive()
    {
        if (!isActiveSetting)
        {
            isActiveSetting = true;
            menuSetting.SetActive(true);

            if (menuPasue.activeSelf == true)
            {
                isActiveSetting= true;
                menuPasue.SetActive(false);
            }
        }
        else
        {
            isActiveSetting = false;
            menuSetting.SetActive(false);
        }
    }
}
