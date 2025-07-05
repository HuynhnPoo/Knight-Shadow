using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BtnPause : ButtonBase
{
    //  private static bool isPaused = false;
    //protected bool isPaused = false;
    [SerializeField] private GameObject menuSetting => UIManager.Instance?.MenuSetting;
    private GameObject menuPause=> UIManager.Instance?.MenuPause;
    protected override void OnClick()
    {
        Pausing();
    }

    private void OnEnable()
    {
    }

    // bat menu pasue
    protected void Pausing()
    {
        if (!GameManager.Instance.IsPaused) 
        {
            GameManager.Instance.IsPaused = true;
            menuPause.SetActive(true);      
            menuSetting.SetActive(false);  
            Time.timeScale = 0;            
        }
        else 
        {
            if (menuPause.activeSelf == true)
            {
                GameManager.Instance.IsPaused = false;
                menuPause.SetActive(false);
                Time.timeScale = 1;         
            }
          
            else if (menuSetting.activeSelf == true)
            {
                menuSetting.SetActive(false); 
                menuPause.SetActive(true); 
            }
           
        }
    }
}
