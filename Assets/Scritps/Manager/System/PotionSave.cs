using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TypePotion;


public class PotionSave
{
    [System.Serializable]
    private class PotionData
    {
        public List<PotionInfo> potions = new List<PotionInfo>();

    }

    [System.Serializable]
    private struct PotionInfo
    {
        public string namePotion;
        public int typePotion;
        public int valuePotion;

        public PotionInfo(string namePotion, int typePotion, int valuePotion)
        {
            this.namePotion = namePotion;
            this.typePotion = typePotion;
            this.valuePotion = valuePotion;
        }


    }

    public static void AddPotion(ItemShopData itemShop)
    {
        Queue<ItemShopData> queue = LoadQueue();
        queue.Enqueue(itemShop);
        SaveQueue(queue);
    }
    public static int UsePotion(string nameItem)
    {
        Queue<ItemShopData> queue = LoadQueue();
        Queue<ItemShopData> newQueue = new Queue<ItemShopData>();

        int amount = 0;

        while (queue.Count > 0)
        {
            ItemShopData itemShop = queue.Dequeue();
            if (itemShop.itemName == nameItem && amount ==0)
            {
                Debug.Log("hien thi ra " + itemShop.itemName + itemShop.typePotion + itemShop.value);
                amount = itemShop.typePotion == TypePotionList.POTIONFULL ? itemShop.value :
                   itemShop.typePotion == TypePotionList.POTIONHAFT ? itemShop.value : 0;

                Debug.Log("hien thi ra " + amount);


            }
            else
            {
                newQueue.Enqueue(itemShop);
            }
        }

        SaveQueue(newQueue);
        return amount;
    }

    private static void SaveQueue(Queue<ItemShopData> queue)
    {

        PotionData data = new PotionData();
        foreach (ItemShopData potion in queue)
        {
            data.potions.Add(new PotionInfo(potion.itemName, (int)potion.typePotion, potion.value));


        }

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(StringSave.potionSave, json);
        PlayerPrefs.Save();
    }


    public static int GetPotionCount(string namePotion)
    {
        Queue<ItemShopData> queue = LoadQueue();
        int count = 0;
        foreach (ItemShopData potion in queue)
        {
            if (potion.itemName == namePotion)
            {
                count++;
            }
        }
        return count;
    }

    public static Queue<ItemShopData> LoadQueue()
    {
        Queue<ItemShopData> queue = new Queue<ItemShopData>();

        if (PlayerPrefs.HasKey(StringSave.potionSave))
        {
            string json = PlayerPrefs.GetString(StringSave.potionSave);
            PotionData data = JsonUtility.FromJson<PotionData>(json);
            foreach (PotionInfo info in data.potions)
            {
                ItemShopData item = ScriptableObject.CreateInstance<ItemShopData>();
                item.itemName = info.namePotion;
                item.typePotion = (TypePotionList)info.typePotion;
                item.value = info.valuePotion;

                Debug.Log(item.itemName);
                queue.Enqueue(item);
            }
        }
        return queue;
    }

    public static void ClearPotion()
    {
        PlayerPrefs.DeleteKey(StringSave.potionSave);
        PlayerPrefs.Save();
    }


}
