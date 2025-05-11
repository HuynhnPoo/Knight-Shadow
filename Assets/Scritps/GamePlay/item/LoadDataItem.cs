using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadDataItem : MonoBehaviour
{

    [SerializeField] private AssetLabelReference labelIEm;
    public ItemData ItemData;
    private int value;



    private void OnEnable()
    {
        if (ItemData == null)
        {
            GameManagerAssetsLoad.LoadingGameAssetByLabel(labelIEm, gameObject.name, this, LoadSOItem);// load SO cho item bằng addressable 
        }

    }


    void LoadSOItem(ScriptableObject scriptableObject)
    {
        ItemData = scriptableObject as ItemData;
    }



}
