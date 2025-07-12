using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemButton : ButtonBase
{
    [SerializeField] private ShopItem shopBuy;
    public int index;
    protected override void OnClick()
    {
        Debug.Log("hien thi ra thuc hien");
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
