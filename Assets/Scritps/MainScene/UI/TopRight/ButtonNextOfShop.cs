using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextOfShop : ButtonBase
{
    private ChangeListShop itemShop;

    private void OnEnable()
    {
        itemShop = FindObjectOfType<ChangeListShop>();
    }

    protected override void OnClick() => itemShop.ChangeShopNext();
}
