using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : ButtonBase
{
    //  private static bool isActiveSetting = false;
    [SerializeField] private GameObject menuSetting => UIManager.Instance?.MenuSetting;
        private GameObject menuPause => UIManager.Instance?.MenuPause;

  
    protected override void OnClick() => SettingActive();

    void SettingActive()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        if (!GameManager.Instance.IsPaused) 
        {
            GameManager.Instance.IsPaused = true;
            menuSetting.SetActive(true);    
            menuPause.SetActive(false);     
            Time.timeScale = 0;            
        }
        else 
        {
            if (menuSetting.activeSelf == true)
            {
                GameManager.Instance.IsPaused = false;
                menuSetting.SetActive(false);
                Time.timeScale = 1;        
            }
           
            else if (menuPause.activeSelf == true)
            {
                menuPause.SetActive(false);   // Tắt Pause
                menuSetting.SetActive(true);  // Bật Setting
            }
            
        }
    }
}
