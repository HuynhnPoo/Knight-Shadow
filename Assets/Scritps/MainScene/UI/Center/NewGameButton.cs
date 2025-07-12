using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : ButtonBase
{
    [SerializeField]private ShopManager[] shopManager;
    private CharactorSelector charactorSelector;
    private GameObject listItemsShop;


    private void OnEnable()
    {
        shopManager = FindObjectsOfType<ShopManager>(true);
    }

    protected override void Start()
    {
        base.Start();
        //if (shopManager == null)
        listItemsShop = FindGameObjectByNameHide.FindGameObjectByName("Player_List");
        charactorSelector = listItemsShop.GetComponentInChildren<CharactorSelector>();
        //   shopManager = listItemsShop.GetComponentInChildren<ShopManager>();
    }

    protected override void OnClick()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
        foreach (ShopManager shop in shopManager)
        {
            shop.NewGame();
        }
        charactorSelector.SelectCharacter(0); //khoi tao lai nhan vat la 0
        PlayerPrefs.SetInt("NewGame", 1);
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }


}
