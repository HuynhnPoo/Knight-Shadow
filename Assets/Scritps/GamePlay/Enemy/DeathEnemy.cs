using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private EnemyInfo enemyInfo;
    [SerializeField] private LoadAssetItem itemAsset;

    float minSpawnMele = 0.05f;
    float minSpawnRange = 0.08f;
    float maxSpawn = 0.2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {


            itemAsset.SpawnItem(7, this.transform);

        }
        if (Input.GetKey(KeyCode.M))
        {


            itemAsset.SpawnItem(6, this.transform);

        }
    }

    private void OnEnable()
    {
        if (itemAsset == null)
        {
            enemyInfo=GetComponent<EnemyInfo>();
            itemAsset = GetComponentInParent<LoadAssetItem>();
        }
    }
   
   public void DropItem()
    {
        System.Random random = new System.Random();
        double randomNumber = random.NextDouble();

        Debug.Log("hie thi ramdom" + randomNumber);
        switch (enemyInfo.NameEnemy)
        {
            case "Slime":
            case "Sekeleton":
            case "Orc":
                if (randomNumber <= minSpawnMele)
                {
                    Debug.Log("thuc hien sinh tra cac item ngon");
                    itemAsset.SpawnItem(0, this.transform);
                    itemAsset.SpawnItem(3, this.transform);
                }

                else if (randomNumber > minSpawnMele && randomNumber <=maxSpawn)
                {
                    Debug.Log("thuc hien sinh ra vu khi");
                    itemAsset.SpawnItem(1, this.transform);
                    itemAsset.SpawnItem(4, this.transform);

                    itemAsset.SpawnItem(random.NextDouble() < (maxSpawn / minSpawnMele) ? 6 : 7, this.transform);
                }
                else
                {
                    itemAsset.SpawnItem(1, this.transform);
                    itemAsset.SpawnItem(4, this.transform);
                }
                break;

            case "Vampire":
            case "Plant":
                if (randomNumber <= minSpawnRange)
                {

                    Debug.Log("thuc hien sinh tra cac item ngon");
                    itemAsset.SpawnItem(0, this.transform);
                    itemAsset.SpawnItem(3, this.transform);

                }

                else if (randomNumber > minSpawnRange && randomNumber <=maxSpawn)
                {

                    Debug.Log("thuc hien sinh ra vu khi");
                    itemAsset.SpawnItem(2, this.transform);
                    itemAsset.SpawnItem(5, this.transform);


                    itemAsset.SpawnItem(random.NextDouble() < (maxSpawn / minSpawnRange) ? 6 : 7, this.transform);
                   
                }

                else
                {
                    itemAsset.SpawnItem(2, this.transform);
                    itemAsset.SpawnItem(5, this.transform);
                }
                break;

            default:
                Debug.LogWarning("Không dung quái");
                break;

        }
    }


}
