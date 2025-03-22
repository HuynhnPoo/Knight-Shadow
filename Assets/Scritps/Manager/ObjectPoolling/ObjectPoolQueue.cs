using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPoolQueue : ObjectPoolBase
{
    private Queue<GameObject> queue = new Queue<GameObject>();
    [SerializeField] protected GameObject objectsPrefabs;
    int size = 2;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    public override void InitializedToPool()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(objectsPrefabs);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }
    public override GameObject GetObjectPool()
    {
        if (queue.Count <= 0)
        {
           GameObject obj= Instantiate(objectsPrefabs); 
            obj.SetActive(false);
            queue.Enqueue(obj);
            return obj;
        }

        else
        {
            GameObject obj= queue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
    }


    public override void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        queue.Enqueue(obj); 
    }


    
}
