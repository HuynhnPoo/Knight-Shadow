using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private DropTableItem dropTableItem = new DropTableItem();

    [SerializeField] private LoadAssetItem itemAsset;
    private AssetLabelReference labelReference = new AssetLabelReference { labelString = "item" };
    private EnemyInfo enemyInfo;
    float minSpawnMele = 0.05f;
    float minSpawnRange = 0.08f;
    float maxSpawn = 0.2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            dropTableItem.DropItem(itemAsset, this.transform,true);
        }
        /* if (Input.GetKey(KeyCode.M))
         {


             itemAsset.SpawnItem(8, this.transform);

         }*/
    }


    private void OnEnable()
    {
        if (itemAsset == null)
        {
            enemyInfo = GetComponent<EnemyInfo>();
            itemAsset = GetComponentInParent<LoadAssetItem>();

            GameManagerAssetsLoad.LoadingGameAssetByLabel(labelReference, this, itemsLoading =>
            {
                if (itemsLoading != null) dropTableItem.SetItems(itemsLoading);
            });
            //dropTableItem.SetItems(loadedItems);
        }
    }




    // private void OnItemsLoaded(AsyncOperationHandle<IList<ItemData>> handle) {    }
    public void DropItem()
    {
       bool isMeleeEnemy;

        switch (enemyInfo.NameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":
                isMeleeEnemy = true;
                dropTableItem.DropItem(itemAsset, this.transform,isMeleeEnemy);
                break;

            case "Vampire":
            case "Plant":
                isMeleeEnemy = false;
                dropTableItem.DropItem(itemAsset, this.transform,isMeleeEnemy);

                break;

            default:
                Debug.LogWarning("Không dung quái");
                break;

        }

    }
}