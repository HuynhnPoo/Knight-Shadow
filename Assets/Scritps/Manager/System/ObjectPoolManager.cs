using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<TCollection>
{
    private TCollection pool;
    private GameObject[] prefabs;
    private Transform parent;
    private int allPrefabsCreated = 0;

    // khoi taoj objetc pool voi 1 game object
    public ObjectPool(GameObject prefab, int initialSize, Transform parent = null)
    {
        this.prefabs = new GameObject[] { prefab };
        this.parent = parent;
        InitializePool();
        PreloadObjects(initialSize);
    }


    // khoi tao object pool voi 1 mang gameobject
    public ObjectPool(GameObject[] prefabs, int initialSize, Transform parent = null)
    {
        this.prefabs = prefabs;
        this.parent = parent;
        InitializePool();
        PreloadObjects(initialSize);
    }


    // khoi tao Tcollection la kieu cau truc gi
    private void InitializePool()
    {
        if (typeof(TCollection) == typeof(Stack<GameObject>))
            pool = (TCollection)(object)new Stack<GameObject>();
        else if (typeof(TCollection) == typeof(Queue<GameObject>))
            pool = (TCollection)(object)new Queue<GameObject>();
        else if (typeof(TCollection) == typeof(List<GameObject>))
            pool = (TCollection)(object)new List<GameObject>();
        else Debug.LogError("TCollection must be Stack<GameObject>, Queue<GameObject>, or List<GameObject>");
    }


    // khoi tao pool vaf dua vao trong game object vafo trong pool
    private void PreloadObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = CreateObject();
            ReturnObject(obj);
        }
    }

    private GameObject CreateObject()
    {
        int index = Random.Range(0, prefabs.Length);
        GameObject obj = Object.Instantiate(prefabs[index], parent);
        allPrefabsCreated++;
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {

        GameObject obj = null;
        if (pool is Stack<GameObject> stack && stack.Count > 0)
            obj = stack.Pop();
        else if (pool is Queue<GameObject> queue && queue.Count > 0)
            obj = queue.Dequeue();
        else if (pool is List<GameObject> list && list.Count > 0)
        {
            obj = list[0];
            list.RemoveAt(0);
        }

        else
        {
            obj = CreateObject();
        }

        return ActivateObject(obj);
    }

    //trả  gameovject vào grong pool
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        if (pool is Stack<GameObject> stack)
            stack.Push(obj);
        else if (pool is Queue<GameObject> queue)
            queue.Enqueue(obj);
        else if (pool is List<GameObject> list)
            list.Add(obj);
    }

    
    private GameObject ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
        return obj;
    }


    // kiem tra các object đã bị tat het hay chưa
    public bool HasActiveObject()
    {

        bool hasActiveObjects = false;

        if (pool is Stack<GameObject> stack)
        {
            return stack.Count < allPrefabsCreated;
        }
        else if (pool is Queue<GameObject> queue)
        {

            return queue.Count < allPrefabsCreated;
        }
        else if (pool is List<GameObject> list)
        {
            hasActiveObjects = (list.Count < allPrefabsCreated);
        }

        return hasActiveObjects;
    }

    public void ClearAllObject() 
    {
        if (pool is Stack<GameObject> stack)
        {
            while (stack.Count > 0)
            {
                GameObject obj = stack.Pop();
                if (obj != null) Object.Destroy(obj);
            }
        }
        else if (pool is Queue<GameObject> queue)
        {
            while (queue.Count > 0)
            {
                GameObject obj = queue.Dequeue();
                if (obj != null) Object.Destroy(obj);

            }
        }
        else if (pool is List<GameObject> list)
        {
            foreach(var obj in list)
            {
                if(obj != null) Object.Destroy(obj);     
            }
            list.Clear();
        }
    }

    public void ChangeObjectInPool(GameObject newoObject)
    {
       ClearAllObject();
        this.prefabs = new GameObject[] { newoObject };
        PreloadObjects(10);

    }
}