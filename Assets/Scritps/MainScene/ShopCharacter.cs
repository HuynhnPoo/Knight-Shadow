using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopCharacter : ShopManager
{

    [SerializeField] private CharacterShopData[] shopData;

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManagerAssetsLoad.LoadingGameAssetByLabel(labelShopData, this, LoadShopData); //loading data
    }

    void LoadShopData(List<ScriptableObject> loadedObjects)
    {
        if (loadedObjects != null && loadedObjects.Count > 0)
        {
            shopData = loadedObjects
                .OfType<CharacterShopData>() // Ensure only CharacterShopData objects are included
                .ToArray();

            Debug.Log($"Loaded {shopData.Length} CharacterShopData objects into shopData.");
        }
        else
        {
            Debug.LogWarning("Failed to load CharacterShopData objects or no objects found.");
            shopData = new CharacterShopData[0]; // Initialize as empty array if loading fails
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopData.Length; i++)
        {
            ActiveButtonBuy(shopData[i].isBought, i); //duyet vaf actice
        }
    }


    //new game resst tat car veef ban ddau
    public override void NewGame()
    {

        Debug.Log("hien thi thuc hien reseet chảarter");
        PlayerPrefs.SetInt(StringSave.coinSave, 0); // set coin ve khong
        PlayerPrefs.Save();
        for (int i = 0; i < shopData.Length; i++)
        {
            shopData[i].isBought = false;
            buyButton[i].gameObject.SetActive(true); // bat tat ca cac nut

        }
    }

    // mua nhan vat
    public override void PurchasingEnity(int index)
    {
        if (currentCoin >= shopData[index].price && !shopData[index].isBought)
        {
            shopData[index].isBought = true;
            currentCoin -= shopData[index].price;
            PlayerPrefs.SetInt(StringSave.coinSave, currentCoin);

            ActiveButtonBuy(shopData[index].isBought, index);
        }
    }

    //actice nhan vat khi mua nhan vat
    void ActiveButtonBuy(bool isBought, int index)
    {
        if (isBought)
        {
            buyButton[index].gameObject.SetActive(false);
        }

    }
}
