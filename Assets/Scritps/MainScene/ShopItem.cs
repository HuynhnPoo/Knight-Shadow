using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopItem : ShopManager
{

   [SerializeField] private ItemShopData[] itemData;

    protected override void OnEnable()
    {
        base.OnEnable();

        GameManagerAssetsLoad.LoadingGameAssetByLabel(labelShopData, this, loadShop); //loading data

    }

    void loadShop(List<ScriptableObject> loadedObjects)
    {

        if (loadedObjects != null && loadedObjects.Count > 0)
        {
            itemData = loadedObjects
                .OfType<ItemShopData>() // Ensure only CharacterShopData objects are included
                .ToArray();

            Debug.Log($"Loaded {itemData.Length} CharacterShopData objects into shopData.");
        }
        else
        {
            Debug.LogWarning("Failed to load CharacterShopData objects or no objects found.");
            itemData = new ItemShopData[0]; // Initialize as empty array if loading fails
        }
    }

    public override void NewGame()
    {
        Debug.Log("hie  thuc thuc hiejn cua hafm nayf");
        if (itemData == null) return;
        foreach (var item in itemData) 
        {
            item.quantity = 0;

        }
        PotionSave.ClearPotion();
    }

    public override void PurchasingEnity(int index)
    {

        Debug.Log("hien thi ra thục hien mua item "+ index);
        if (currentCoin >= itemData[index].price && itemData[index].quantity <= itemData[index].maxQuantity)
        {

            Debug.Log("hien thi thục hiẹn thanh cong mua item");
            itemData[index].quantity++ ; 
            currentCoin -= itemData[index].price;
            PlayerPrefs.SetInt(StringSave.coinSave, currentCoin);

            PotionSave.AddPotion(itemData[index]);

        }
    }

    
}
