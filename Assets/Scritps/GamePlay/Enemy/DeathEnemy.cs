using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DeathEnemy : MonoBehaviour
{
    private DropTableItem dropTableItem = new DropTableItem();
    [SerializeField] private LoadAssetItem itemAsset;
    private AssetLabelReference labelReference = new AssetLabelReference { labelString = "item" };
    private EnemyInfo enemyInfo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            dropTableItem.DropItem(itemAsset, this.transform, true);
        }
    }


    private void OnEnable()
    {
        enemyInfo = GetComponent<EnemyInfo>();
        itemAsset = GetComponentInParent<LoadAssetItem>();

        GameManagerAssetsLoad.LoadingGameAssetByLabel(labelReference, this, itemsLoading =>
        {
            if (itemsLoading != null) dropTableItem.SetItems(itemsLoading);
        });
        //dropTableItem.SetItems(loadedItems);
    }

    public void DropItem()
    {

        bool isMeleeEnemy = false;

        if (enemyInfo.IsBoss) DeathingBoss(isMeleeEnemy);

        else if (!enemyInfo.IsBoss) DeathingOfEnemy(isMeleeEnemy);
    }

    void DeathingOfEnemy(bool isMeleeEnemy)
    {
        switch (enemyInfo.NameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":
                isMeleeEnemy = true;
                dropTableItem.DropItem(itemAsset, this.transform, isMeleeEnemy);
                break;

            case "Vampire":
            case "Plant":
                isMeleeEnemy = false;
                dropTableItem.DropItem(itemAsset, this.transform, isMeleeEnemy);

                break;

            default:
                Debug.LogWarning("Không dung quái");
                break;

        }
    }

    public void DeathingBoss(bool isMeleeEnemy)
    {
        Vector2 posItemSpawn=new Vector2(this.transform.position.x,this.transform.position.y);
        switch (enemyInfo.NameEnemy)
        {
            case "Lucifer_Boss":
                isMeleeEnemy = true;
                for (int i = 0; i <4 ; i++)
                {
                    posItemSpawn=Random.insideUnitCircle * 6;

                    dropTableItem.DropItem(itemAsset, this.transform, isMeleeEnemy);
                }
                break;
            default:
                // Mặc định cho boss nếu không có trường hợp cụ thể, dùng melee
                // enemyAttack.RangedAttackPlayer(this.transform.position, DirectionOfEnemy(), this);

                break;
        }
    }
   
}

