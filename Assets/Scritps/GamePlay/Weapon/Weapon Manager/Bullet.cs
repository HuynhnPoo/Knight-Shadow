using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    protected float  speed;
    protected int distanceMax, dameWeapon;
    protected Vector2 spawnPos;

    protected RangedWeapon rangedWeapon;
    protected Rigidbody2D rbBullet;

    protected virtual void OnEnable()
    {
        if (rbBullet == null) rbBullet = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;

    }

    protected virtual void Update()
    {
        CheckDistance(distanceMax);
    }


    // bố trí ranged weapon
    public void SetWeapon(RangedWeapon rangedWeapon)
    {
        this.rangedWeapon = rangedWeapon;
        spawnPos = transform.position;
    }


    // kie  tra vi tri cua bullet 

    public virtual void CheckDistance(int distanceMax)
    {
        if (rangedWeapon == null) return;
        float distance = Vector2.Distance(spawnPos, transform.position);
        if (distance > distanceMax)
        {
            rangedWeapon.ReturnToPool(this.gameObject);
        }
    }

    public abstract void HitObject(Collider2D collider, int dameWeapon);

    // di chuyen bullet
    public abstract void Move(Vector2 direction);

}
