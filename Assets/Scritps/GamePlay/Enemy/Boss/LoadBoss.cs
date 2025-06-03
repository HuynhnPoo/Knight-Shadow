using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadBoss : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    public AssetReference[] itemAssets;

    [SerializeField] private GameObject uuuuuuuuuu;

    private void Awake()
    {
        // GameManagerAssetsLoad.LoadingGameAsset(itemAssets, list, this); // load các item bang addressable

    }

    private void Start()
    {

        //PositonOfWorld positonOfWorld = new PositonOfWorld();
        //if (uuuuuuuuuu != null )
        //Instantiate(uuuuuuuuuu, positonOfWorld.TakePositonOfWorld(), Quaternion.identity);
        //Debug.Log("hien thi ra vij tris sinh vat thee cua " + uuuuuuuuuu.transform.position);
    }
    // ham sinh item
    public void SpawnBoss(int index, Transform posEnemy)
    {

        GameObject obj = Instantiate(list[index], posEnemy.position, Quaternion.identity);
    }
}
