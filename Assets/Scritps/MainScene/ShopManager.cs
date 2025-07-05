using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;


public abstract class ShopManager : MonoBehaviour
{
  
    [SerializeField] protected Button[] buyButton;
    protected int currentCoin;


    [SerializeField] protected AssetLabelReference labelShopData;



    protected virtual void OnEnable()
    {
        
        buyButton = GetComponentsInChildren<Button>();
        currentCoin = PlayerPrefs.GetInt(StringSave.coinSave, 0);

    }
 
    public abstract void NewGame();
    public abstract void PurchasingEnity(int index);



}
