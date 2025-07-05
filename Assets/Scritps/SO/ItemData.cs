using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemType;

[CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObject/Item")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public float weigth; // ti le xuat hien


    public int value;// gia tri cua vat pham
    public int timeDestroys;
    public int timeStart;
    public ItemTypeList type = ItemTypeList.GOLD;
}
        