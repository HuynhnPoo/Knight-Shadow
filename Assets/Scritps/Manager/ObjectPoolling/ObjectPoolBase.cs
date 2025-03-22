using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolBase : MonoBehaviour
{
    [SerializeField]protected Transform holdObject;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        InitializedToPool();    
    }

    //khoi tao pool
    public abstract void InitializedToPool();

    //lay doi tuoeng tu pool ra 
    public  abstract GameObject GetObjectPool();

    //tat doi tuong 
    public abstract void ReturnToPool(GameObject obj);
  
}
