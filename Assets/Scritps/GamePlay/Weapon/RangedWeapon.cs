using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private Bullet bullet;
    private ObjectPool<Queue<GameObject>> pool;
    [SerializeField] private Transform holderBullet;
    int size = 10;

    enum TypeBullet
    {
        Fireball,
        Bullet
    }

    Quaternion quaternion;
   
    void InitPool(int index)
    {
        if (pool == null)
        {
            pool = new ObjectPool<Queue<GameObject>>(bulletPrefabs[index].gameObject, size, holderBullet); // khoi tạo pool
        }
        else
        {
            pool.ChangeObjectInPool(bulletPrefabs[index].gameObject);
        }

    }

    private void OnEnable()
    {
        if (gameObject.name == "Magic")
        {
            InitPool((int) TypeBullet.Fireball);
        }

        else if (gameObject.name == "bow")
        {
            InitPool((int)TypeBullet.Bullet);
        }
    }

    // chuyen bullet
    private void Update()
    {

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
