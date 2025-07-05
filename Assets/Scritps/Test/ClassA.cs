using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassA : BaseOOP
{
    int c = 9;
    public override void TestB()
    {
        Debug.Log("hien thi thuc hien c"+c);
    }

    private void Awake()
    {
        a = 9;
        b = 7;
    }
}
