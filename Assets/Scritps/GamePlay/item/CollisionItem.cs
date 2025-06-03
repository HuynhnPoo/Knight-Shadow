using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ItemType;

public class CollisionItem : MonoBehaviour
{
    float timer = 0;
    int coolDown = 5;
    [SerializeField] private ItemType itemType;
    [SerializeField] LoadDataItem dataItem;

    private float contactTimer = 0f;
    private bool isPlayerContact = false;

    // Start is called before the first frame update
    void Start()
    {
        dataItem = GetComponent<LoadDataItem>();
        itemType = GetComponent<ItemType>();
    }

    // Update is called once per frame
    void Update()
    {
        ConTactWithWeapon();
    }

    void ConTactWithWeapon()
    {
        if (isPlayerContact && itemType.itemTypeList == ItemTypeList.WEAPON)
        {
            AnimationWeapon selectWeapon = GameManager.Instance.PlayerCrtl.gameObject.GetComponentInChildren<AnimationWeapon>();
            contactTimer += Time.deltaTime;
            if (contactTimer >= 2.0f)
            {

                selectWeapon.SelectWeapon(dataItem.ItemData.value); // item value để chưa index của vũ khí
                Destroy(this.gameObject);
                contactTimer = 0f;
                isPlayerContact = false;
            }
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bắt đầu tính thời gian khi va chạm với player
        if (collision.gameObject.CompareTag(TagInGame.player) && this.gameObject.CompareTag(TagInGame.item))
        {
            isPlayerContact = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Nếu là player va chạm với item (không phải weapon)
        if (collision.gameObject.CompareTag(TagInGame.player) && this.gameObject.CompareTag(TagInGame.item) && itemType.itemTypeList != ItemTypeList.WEAPON)
        {
            StartCoroutine(DestroyCollison(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Khi player rời khỏi vùng va chạm, reset thời gian
        if (collision.gameObject.CompareTag(TagInGame.player))
        {
            isPlayerContact = false;
            contactTimer = 0f;
        }
    }

    IEnumerator DestroyCollison(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f); // sau 0.5s sẽ thực hiện

        switch (itemType.itemTypeList)
        {
            case ItemTypeList.GOLD:
                GameManager.Instance.AddGold(dataItem.ItemData.value);
                break;
            case ItemTypeList.EXPERINCE:
                GameManager.Instance.AddExperice(dataItem.ItemData.value);
                break;
            case ItemTypeList.POTIONHEATH:
                GameManager.Instance.PlayerCrtl.CharacterInfo.AddHeath(dataItem.ItemData.value);
                break;
            case ItemTypeList.POTIONMANA:
                GameManager.Instance.PlayerCrtl.CharacterInfo.AddHeath(dataItem.ItemData.value);
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }
}