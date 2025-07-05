using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShopButton : ButtonBase
{
    private static bool isShopCharacter=true;
   [SerializeField] private GameObject pnShopCharacter;
   [SerializeField] private GameObject pnShopItem;


    private void OnEnable()
    {
        pnShopCharacter = UIManager.Instance?.PnShop;
        pnShopItem = UIManager.Instance?.PnShopItem;

    }
    protected override void OnClick() => ChangeShop();
    void ChangeShop()
    {
        if (isShopCharacter)
        {
            isShopCharacter = false;
            pnShopCharacter.SetActive(false);
            pnShopItem.SetActive(true);
        }
        else
        {
            isShopCharacter = true;
            pnShopCharacter.SetActive(true);
            pnShopItem.SetActive(false);
        }
    }
}
