using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolList : ObjectPoolBase
{
    private List <GameObject> list= new List <GameObject> ();
   


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
            obj.SetActive (false);
            list.Add (obj);  
        }
    }

    public override GameObject GetObjectPool() 
    {
            foreach (GameObject obj in list) 
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive (true);

                    return obj;
                }
            }

        GameObject newObj = Instantiate(objectsPrefabs);
        newObj.SetActive(false);
        list.Add(newObj);
        return newObj;
    }


    public  override void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
