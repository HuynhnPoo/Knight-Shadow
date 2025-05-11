using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAssetItem : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public AssetReference[] itemAssets;
  
    private void Awake()
    {
        GameManagerAssetsLoad.LoadingGameAsset(itemAssets, list, this); // load các item bang addressable
        
    }
    // ham sinh item
    public void SpawnItem(int index,Transform posEnemy)
    {
        GameObject obj = Instantiate(list[index],posEnemy.position,Quaternion.identity); 
    }
}
