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
}