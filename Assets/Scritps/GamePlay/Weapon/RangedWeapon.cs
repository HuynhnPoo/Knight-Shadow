using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField]private Bullet[] bulletPrefabs;
    [SerializeField] private Bullet bullet;
    private ObjectPool<Queue<GameObject>> pool;
    [SerializeField] private Transform holderBullet;
    int currentBulletIndex=0;
    int size = 10;


    Quaternion quaternion;
    private void Awake()
    {
        InitPool();
    }

    void InitPool()
    {
        if (pool == null)
        {
            pool = new ObjectPool<Queue<GameObject>>(bulletPrefabs[currentBulletIndex].gameObject, size, holderBullet); // khoi tạo pool
        }
        else
        {
            pool.ChangeObjectInPool(bulletPrefabs[currentBulletIndex].gameObject);
        }

    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha4))
        {
            NextToBullet();
        } 
        if (Input.GetKey(KeyCode.Alpha5))
        {
            PrevioustoBullet();
        }
    }




    public override void Attacking()
    {
        SpawnBullet();
    }


    void NextToBullet()
    {
        currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;

        InitPool();

        Debug.Log("hien thi va thuc hien "+ bulletPrefabs[currentBulletIndex].gameObject.name);
    }

    void PrevioustoBullet()
    {
        currentBulletIndex=(currentBulletIndex -1 + bulletPrefabs.Length) % bulletPrefabs.Length;
        InitPool();
        Debug.Log("hien thi va thuc hien " + bulletPrefabs[currentBulletIndex].gameObject.name);
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
