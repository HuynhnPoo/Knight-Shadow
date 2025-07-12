using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopItem : ShopManager
{

    [SerializeField] private ItemShopData[] itemData;
    static bool isReset = false;

    private const string IS_RESET_KEY = "IsReset";

    private void Awake()
    {
        isReset = PlayerPrefs.GetInt(IS_RESET_KEY, 0) == 1;
    }

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
        if (isReset)
        {
            Debug.Log("hien thi" + isReset);
            foreach (var item in itemData)
            {
                Debug.Log(" thien thanh hafm " + isReset + 0);
                item.quantity = 0;

            }

            isReset = false;
            SaveIsReset();
        }
    }



    public override void NewGame()
    {
        isReset = true; // Set isReset to true
        Debug.Log("hien thi ra thu hien ham true" + isReset);
        SaveIsReset(); // Save isReset to PlayerPrefs
        PotionSave.ClearPotion();
    }
    private void SaveIsReset()
    {
        PlayerPrefs.SetInt(IS_RESET_KEY, isReset ? 1 : 0);
        PlayerPrefs.Save(); // Ensure the data is written to disk
    }
    public override void PurchasingEnity(int index)
    {
        Debug.Log("hien thi ra thuc hien");
        if (currentCoin >= itemData[index].price && itemData[index].quantity > itemData[index].maxQuantity)
        {
            Debug.Log("hien thi thục hiẹn thanh cong mua item");
            itemData[index].quantity++;
            currentCoin -= itemData[index].price;
            PlayerPrefs.SetInt(StringSave.coinSave, currentCoin);
            PotionSave.AddPotion(itemData[index]);


        }
    }
}
