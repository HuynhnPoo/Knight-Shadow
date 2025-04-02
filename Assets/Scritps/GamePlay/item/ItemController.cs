using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ItemController : MonoBehaviour
{
    float timer = 0;
    int coolDown = 5;

    [SerializeField] private AssetLabelReference labelIEm;
    public ItemData ItemData;
    private int value;

    private void OnEnable()
    {
        if (ItemData == null)
            GameManagerAssetsLoad.LoadingGameAssetByLabel(labelIEm, gameObject.name, this, LoadSOItem);// load SO cho item bằng addressable
        else value = ItemData.value;

    }


    void LoadSOItem(ScriptableObject scriptableObject)
    {
        ItemData = scriptableObject as ItemData;
    }

    void DesTroyByTime()
    {
        timer += 1 * Time.deltaTime;// cong thoi gian len

        // neu time tang len qua coolDown se destroy vat
        if (timer > coolDown)
        {
            Destroy(this.gameObject);
            timer = 0;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // va cham voi vat player se xoa va nhận kinh nhiem với
        StartCoroutine(DestroyCollison(collision));
    }

    IEnumerator DestroyCollison(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f); // sau 0. sẽ thuc hien
                                               //neu game object có cung tag khi cham sẽ xoa
        if (this.gameObject.CompareTag(TagInGame.experice) && collision.gameObject.CompareTag(TagInGame.player))
        {
            GameManager.Instance.AddExperice(ItemData.value);

            Destroy(this.gameObject);
        }
        if (this.gameObject.CompareTag(TagInGame.gold) && collision.gameObject.CompareTag(TagInGame.player))
        {
            GameManager.Instance.AddGold(ItemData.value);

            Destroy(this.gameObject);
        }

    }

}
