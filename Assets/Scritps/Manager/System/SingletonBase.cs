using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        CheckInstance();
    }
     void CheckInstance()
    {
        if (instance != null ) { Destroy(this); }
        else { instance = this as T ; }

    }
}
