using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolList : ObjectPoolBase
{
    private List<GameObject> list = new List<GameObject>();
    [SerializeField] protected GameObject[] objectsPrefabs;
    private int size = 100;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void InitializedToPool()
    {
        for (int i = 0; i < size; i++)
        {
            int index = Random.Range(0, objectsPrefabs.Length);
            GameObject obj = Instantiate(objectsPrefabs[index]);
            obj.transform.parent = holdObject;
            obj.SetActive(false);
            list.Add(obj);
        }
    }

    public override GameObject GetObjectPool()
    {
        foreach (GameObject obj in list)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        int randomIndex = Random.Range(0, objectsPrefabs.Length);
        GameObject newObj = Instantiate(objectsPrefabs[randomIndex]);
        newObj.SetActive(false);
        list.Add(newObj);
        return newObj;
    }

    public bool HasActiveObject()
    {

        bool isEmpty = false;
        foreach (GameObject obj in list)
        {
            if (obj.activeSelf)
            {
                isEmpty = true;
                break;
            }

        }
        return isEmpty;
    }

    public override void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
