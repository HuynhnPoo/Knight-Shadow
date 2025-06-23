using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemType;
[System.Serializable]
public class DropTableItem
{
    public List<ItemData> dropItem;
    public void SetItems(List<ScriptableObject> items)
    {
        dropItem = items
            .OfType<ItemData>()
             .ToList();
    }

    public void SpawnByType(ItemTypeList type, LoadAssetItem itemAsset,Transform posSpawn,bool isMeleeEnemy)
    {
        var filteredItems = dropItem.Where(i=>i.type ==type && i.weigth >0).ToList();
        if (filteredItems.Count == 0) 
        {
            Debug.LogWarning("canh bao");
            return;
        }

        float totalWeight =0;
        float rand=Random.Range(0, totalWeight);
        float currentRand = 0;
        foreach (ItemData item in filteredItems)
        {
            float modifiedWeight = item.weigth;
            if(isMeleeEnemy &&  item.weigth<= 20) //nêu giá tri weight của enemy đánh gần nhỏ hơn 20 sẽ giảm tỉ lệ ra đò hiếm
            {
                modifiedWeight *= 0.5f;
            }
            totalWeight += modifiedWeight;

        }

        foreach (ItemData item in filteredItems)
        {
            float modifiedWeight = item.weigth;

            if (isMeleeEnemy && item.weigth <= 5f)
            {
                modifiedWeight *= 0.5f;
            }

            currentRand += modifiedWeight;
            if (currentRand >= rand)
            {
                itemAsset.SpawnItem(item.itemID, posSpawn);
                break;
            }
        }

    }
    public void DropItem(LoadAssetItem itemAsset,Transform posSpawn,bool isMeleeEnemy)
    {
        double randPercent = Random.Range(0f, 100f); 

       
        SpawnByType(ItemTypeList.GOLD,itemAsset,posSpawn, isMeleeEnemy);
        SpawnByType(ItemTypeList.EXPERINCE,itemAsset,posSpawn, isMeleeEnemy);
        if (randPercent>=15 && randPercent<20) 
        {
            SpawnByType(ItemTypeList.POTIONHEATH, itemAsset, posSpawn, isMeleeEnemy);
            SpawnByType(ItemTypeList.POTIONMANA, itemAsset, posSpawn, isMeleeEnemy);
        }

       
       else if (randPercent<15)
        {
            Debug.Log("Random < 10%, sinh thêm vũ khí");
            SpawnByType(ItemTypeList.WEAPON,itemAsset,posSpawn, isMeleeEnemy);

            SpawnByType(ItemTypeList.POTIONHEATH, itemAsset, posSpawn, isMeleeEnemy);
            SpawnByType(ItemTypeList.POTIONMANA, itemAsset, posSpawn, isMeleeEnemy);
        }
    }
}