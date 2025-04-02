using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{

    [SerializeField] private Bullet bullet;
    int size = 10;
    private ObjectPool<Queue<GameObject>> pool;
    [SerializeField] private Transform holderBullet;
    Quaternion quaternion;
    private void Awake()
    {
        pool = new ObjectPool<Queue<GameObject>>(bullet.gameObject,size,holderBullet); // khoi tạo pool
    }
    public override void Attacking()
    {
        SpawnBullet();
    }

    // ham sinh dan
    public Bullet SpawnBullet()
    {
        Spawning(transform.position);
        return bullet;
    }


    //Lấy viên đạn ra khoi pool
    public void Spawning(Vector2 posSpawn)
    {
        quaternion = transform.parent.rotation;

        GameObject obj = pool.GetObject();
        obj.transform.position = posSpawn;
        obj.transform.rotation = quaternion;

        bullet = obj.GetComponent<Bullet>();

        if (bullet != null)
        {

            bullet.SetWeapon(this);
            Vector2 direction = quaternion * Vector2.right; // Lấy hướng di chuyển
            bullet.Move(direction); // Di chuyển viên đạn    
        }
        else
        {
            Debug.LogError("GameObject được lấy từ pool không có thành phần Bullet!");
        }

    }


    // di chuyen bullet vào pool 
    public void ReturnToPool(GameObject obj)
    {
        pool.ReturnObject(obj);
    }
}
