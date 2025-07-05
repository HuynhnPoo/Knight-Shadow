using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemButton : ButtonBase
{
    private ShopItem shopBuy;
    public int index;
    protected override void OnClick()
    {
        shopBuy.PurchasingEnity(index);
    }

    private void OnEnable()
    {
        if (shopBuy == null)
        {
            shopBuy = GetComponentInParent<ShopItem>();
        }
    }
}
