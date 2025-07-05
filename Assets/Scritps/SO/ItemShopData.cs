using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using static TypePotion;
[CreateAssetMenu(fileName ="NewDataItem",menuName = "ScriptableObject/Item")]
public class ItemShopData : ScriptableObject
{
    public string itemName;
    public int price;
    public int value;
    public TypePotionList typePotion = TypePotionList.NONE;
    public int quantity;
    public int maxQuantity;
}
