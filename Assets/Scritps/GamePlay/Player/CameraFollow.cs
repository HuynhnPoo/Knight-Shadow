using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform playerPos;

    Vector3 offset = new Vector3(0, 0, -10);

    private void Awake()
    {
        playerPos = GameObject.FindWithTag(TagInGame.player).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called last once per frame
    private void LateUpdate()
    {
        Following();   // thuc hien
    }


    //ham de camera chay theo nhan vat
    void Following()
    {
        this.transform.position =playerPos.position+offset;   
    }
}
