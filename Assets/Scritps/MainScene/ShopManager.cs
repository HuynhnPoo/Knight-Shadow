using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private CharacterShopData[] shopData;
    [SerializeField] private Button[] buyButton;
    private int currentCoin;


    [SerializeField] private AssetLabelReference labelShopData;

    // Callback to handle loaded ScriptableObjects
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


    private void OnEnable()
    {
        GameManagerAssetsLoad.LoadingGameAssetByLabel(labelShopData, this, LoadShopData);
        buyButton = GetComponentsInChildren<Button>();
        currentCoin = PlayerPrefs.GetInt(StringSave.coinSave, 0);

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopData.Length; i++)
        {
            ActiveButtonBuy(shopData[i].isBought, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            PlayerPrefs.SetInt(StringSave.coinSave, 0); // set coin ve khong
            PlayerPrefs.Save();
            for (int i = 0; i < shopData.Length; i++)
            {
                shopData[i].isBought = false;
                buyButton[i].gameObject.SetActive(true); // bat tat ca cac nut

            }
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt(StringSave.coinSave, 0); // set coin ve khong
        PlayerPrefs.Save();
        for (int i = 0; i < shopData.Length; i++)
        {
            shopData[i].isBought = false;
            buyButton[i].gameObject.SetActive(true); // bat tat ca cac nut

        }
    }


    public void PurchaseCharacter(int index)
    {
        if (currentCoin >= shopData[index].price && !shopData[index].isBought)
        {
            shopData[index].isBought = true;
            currentCoin -= shopData[index].price;
            PlayerPrefs.SetInt(StringSave.coinSave, currentCoin);

            ActiveButtonBuy(shopData[index].isBought, index);

            Debug.Log("hien thi khi thuc hien " + currentCoin + "va " + shopData[index].isBought);
        }
    }

    void ActiveButtonBuy(bool isBought, int index)
    {
        if (isBought)
        {
            Debug.Log(index);
            buyButton[index].gameObject.SetActive(false);
        }

    }

}
