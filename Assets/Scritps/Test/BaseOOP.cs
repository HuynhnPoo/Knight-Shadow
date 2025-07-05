using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class BaseOOP : MonoBehaviour
{
    protected int a;
    protected int b;

    public virtual void TestA()
    {
        Debug.Log("hien thi ra "+a +" "+b);

        TestB();
    }

    public abstract void TestB();
   
    // Start is called before the first frame update
    void Start()
    {
        TestA();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
