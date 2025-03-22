using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="NewItemData", menuName = "ScriptableObject/Item")]

public class ItemData : ScriptableObject
{
    public int value;

    public int timeDestroys;
}
