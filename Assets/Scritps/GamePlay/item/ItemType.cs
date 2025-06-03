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
