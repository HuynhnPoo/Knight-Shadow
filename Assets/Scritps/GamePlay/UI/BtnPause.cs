using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : ButtonBase
{
    private static bool isPaused = false;
    private GameObject menuPasue;
     private GameObject menuSetting;

    protected override void OnClick() => Pausing();
  
    protected override void Start()
    {
        base.Start();
        menuPasue = UIManager.Instance.MenuPause.gameObject;
        menuSetting = UIManager.Instance.MenuSetting.gameObject;
    }

   // bat menu pasue
    void Pausing()
    {
        if (!isPaused)
        {
            isPaused = true;
            menuPasue.SetActive(true);
            if (menuSetting.activeSelf == true)
            {
                isPaused=true;
                menuSetting.SetActive(false);
            } 
        }
        else
        {
            isPaused = false;
            menuPasue.SetActive(false);
        }
    }


}
