using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Bullet
{
    protected override void OnEnable()
    {
        base.OnEnable();
        speed = 70;
        distanceMax = 4;
        dameWeapon = 3;
    }

    // ham di chuyen vien đạn
    public override void Move(Vector2 direction)
    {
        this.rbBullet.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public override void CheckDistance(int distanceMax)
    {
        base.CheckDistance(distanceMax);
    }

    public override void HitObject(Collider2D collider, int dameWeapon)
    {
        if (collider.gameObject.CompareTag(TagInGame.enemy))
        {

            Debug.Log(" hirn thi quai vat" + collider.gameObject.name);
            int dame = GameManager.Instance.PlayerCrtl.DameAttack() + dameWeapon;
            collider.GetComponent<EnemyInfo>().TakeDame(dame);

            this.rangedWeapon.ReturnToPool(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitObject(collision, dameWeapon);
    }

}
