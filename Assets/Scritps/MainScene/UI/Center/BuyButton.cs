using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuyButton : ButtonBase
{
    private ShopCharacter shopBuy;

    public int index;

    protected override void OnClick()=> shopBuy.PurchasingEnity(index);


    private void OnEnable()
    {
        if (shopBuy == null)
        {
            // Tìm ShopCharacter trước
            shopBuy = GetComponentInParent<ShopCharacter>();
            
        }

    }
}


