using UnityEngine;

public class ItemType:MonoBehaviour
{
    // kieu item
    public enum ItemTypeList
    {
        GOLD,
        EXPERINCE,
        WEAPON,
        POTIONHEATH,
        POTIONMANA
    }

    public ItemTypeList itemTypeList;

}

public class TypePotion
{
    public enum TypePotionList
    {
        NONE,
        POTIONFULL,
        POTIONHAFT
    }

    public TypePotionList itemTypeList;
}

