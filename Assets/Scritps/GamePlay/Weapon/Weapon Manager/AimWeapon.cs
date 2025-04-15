using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    // private int speed = 100;

    float distance = 0.5f;

       // Update is called once per frame
    void Update()
    {


        Vector3 aimDirection = (WorldTooMusePos() - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;



        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);

        Vector3 offset = Vector3.zero;

        //int target = 0;
        if (direction.x > 0)
        {
            offset = Vector3.right * distance;
        }

        if (direction.x < 0)
        {
            offset = Vector3.left * distance;
        }
        if (direction.y > 0)
        {
            offset = Vector3.up * distance;
        }

        if (direction.y < 0)
        {
            offset = Vector3.down * distance;
        }

        Vector3 tagerget = transform.parent.position + offset;


        transform.position = Vector3.Lerp(transform.position, tagerget, 3);

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    Vector3 WorldTooMusePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return worldMousePos;
    }
}
