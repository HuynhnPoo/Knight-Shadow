using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDataCharacterShop",menuName = "ScriptableObject/Shop")]
public class CharacterShopData : ScriptableObject
{
    public string  nameCharacter;
    public Sprite characterSprite;
    public bool isBought;
    public int price;
}
