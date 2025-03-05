using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameAssets : MonoBehaviour
{

    [SerializeField] private AssetReference[] itemAssets;
    [SerializeField] private List<GameObject> itemInstance;

    // Start is called before the first frame update

    private void Awake()
    {

        itemInstance = new List<GameObject>();
        foreach (AssetReference item in itemAssets)
        {
            item.LoadAssetAsync<GameObject>().Completed += (AsyncOperationHandle<GameObject> obj) =>
            {
                if (obj.Status == AsyncOperationStatus.Succeeded)
                {
                    itemInstance.Add(obj.Result);
                    //itemInstance[itemInstance.Count-1].SetActive(false);
                }
                else
                 Debug.LogWarning("chua tai object xong"); return;

            };
        }
    }

    public GameObject GetItem(int index)
    {
       // foreach (AssetReference item in itemAssets) 

        if(index>-1 && index<itemInstance.Count)
            return itemInstance[index].gameObject;
        else 
            return null;
    }
   
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
