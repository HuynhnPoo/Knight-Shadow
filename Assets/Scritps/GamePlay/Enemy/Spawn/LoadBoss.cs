using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadBoss : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public AssetReference[] itemAssets;


    private void Awake()
    {
       // GameManagerAssetsLoad.LoadingGameAsset(itemAssets, list, this);

    }

    private void Start()
    {

        PositonOfWorld positonOfWorld = new PositonOfWorld();
       
    }
    // ham sinh item
    public void SpawnBoss(int index, Transform posEnemy)
    {

        GameObject obj = Instantiate(list[index], posEnemy.position, Quaternion.identity);
    }
}
