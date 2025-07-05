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

        public PotionInfo(string namePotion,int typePotion,int valuePotion) 
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
    public static bool UsePotion()
    {
        Queue<ItemShopData> queue = LoadQueue();
        if (queue.Count > 0)
        {
            ItemShopData type = queue.Dequeue();
            Debug.Log("hien thi ra" + type.ToString());
            SaveQueue(queue);

            return true;
        }
        return false;
    }

    private static void SaveQueue(Queue<ItemShopData> queue)
    {

        PotionData data = new PotionData();
        foreach (ItemShopData potion in queue)
        {
            data.potions.Add(new PotionInfo(potion.itemName,(int)potion.typePotion,potion.value));

        }

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(StringSave.potionSave, json);
        PlayerPrefs.Save();
    }


    public static int  GetPotionCount(string namePotion)
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

        if(PlayerPrefs.HasKey(StringSave.potionSave))
        {
            string json=PlayerPrefs.GetString(StringSave.potionSave);
            PotionData data = JsonUtility.FromJson<PotionData>(json);
            foreach (PotionInfo info in data.potions)
            {
                ItemShopData item = ScriptableObject.CreateInstance<ItemShopData>();
                item.itemName = info.namePotion;
                item.typePotion = (TypePotionList)info.typePotion;
                item.value = info.valuePotion;

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
