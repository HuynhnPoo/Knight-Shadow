using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    [SerializeField] EnemyStateCrtl enemyStateCrtl;

    Vector3 posSpawn; 
    protected override void OnEnable()
    {
        base.OnEnable();
        posSpawn = this.transform.position;
        distanceMax = 9;
        dameWeapon = 3;
        speed = 80;
    }

    public void EnemyStateCrtl(EnemyStateCrtl enemyStateCrtl)
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }
    public override void HitObject(Collider2D collider, int dameWeapon)
    {
        if (collider.gameObject.CompareTag(TagInGame.player))
        {
            int dame = enemyStateCrtl.GetDameOfEnemy() + dameWeapon; // dame cua enemy cong voi dame weapon ra tong dame

            collider.GetComponentInChildren<CharacterInfo>().TakeDame(dame);

            enemyStateCrtl.GetObjectToPool(this.gameObject);// tra ve trong pool
        }
    }

    public override void CheckDistance(int distanceMax)
    {
        float distance = Vector3.Distance(spawnPos,transform.position);

        if (distance > distanceMax) {
            enemyStateCrtl.GetObjectToPool(this.gameObject);// tra ve trong pool
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitObject(collision, dameWeapon);
    }

    public override void Move(Vector2 direction)
    {
        this.rbBullet.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

}
