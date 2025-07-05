using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetting : ButtonBase
{
    private static bool isOpenSetting = false;

    [SerializeField] private GameObject settingPanel;

    private void Awake()
    {
        LoadGameObject();
    }
    void LoadGameObject()
    {
        settingPanel = FindGameObjectByNameHide.FindGameObjectByName(TagInGame.pnSetting);

    }

    // Start is called before the first frame update
    protected override void OnClick()
    {
        OpenShop();
    }

    protected void OpenShop()
    {
        if (!isOpenSetting)
        {
            isOpenSetting = true;
            settingPanel.SetActive(true);
        }
        else
        {
            isOpenSetting = false;
            settingPanel.SetActive(false);
        }
    }
}

