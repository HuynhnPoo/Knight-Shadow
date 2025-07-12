using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonShop : ButtonBase
{

    private static bool isOpenShop=false;
   
    [SerializeField] private GameObject shopPanel => UIManager.Instance?.PnShop;
    [SerializeField] protected GameObject shopPanelItem => UIManager.Instance?.PnShopItem;


    // Start is called before the first frame update
    protected override void OnClick()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        OpenShop();
    }

    protected void OpenShop()
    {
        if (!isOpenShop)
        {
            isOpenShop = true;
            shopPanel.SetActive(true);
           
        }
        else
        {
            isOpenShop= false;
            shopPanel.SetActive(false);

            if (shopPanelItem.activeSelf == true)
            {
                shopPanelItem.SetActive(false);
            }
        }
    }
}
