using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private EnemyStateCrtl enemyStateCrtl;
    protected override void OnEnable()
    {
        base.OnEnable();

        distanceMax = 9;
        dameWeapon = 3;
        speed = 80;

    }


    //ham khoi tạo thong số cho bullet 
    public void Init(Vector3 spawnPosition)
    {
        spawnPos = spawnPosition;
        transform.position = spawnPosition;
    }
    
    //chuyen enemey state ctrl đẻ su dung
    public void SetEnemyStateCrtl(EnemyStateCrtl enemyStateCrtl)
    {
        this.enemyStateCrtl = enemyStateCrtl;
    }

    //ham khi xu ly va cham với object
    public override void HitObject(Collider2D collider, int dameWeapon)
    {
        if (collider.gameObject.CompareTag(TagInGame.player))
        {
            int dame = enemyStateCrtl.GetDameOfEnemy() + dameWeapon; // dame cua enemy cong voi dame weapon ra tong dame

            collider.GetComponentInChildren<CharacterInfo>().TakeDame(dame);

            enemyStateCrtl.GetObjectToPool(this.gameObject);// tra ve trong pool
        }
    }

    protected override void Update()
    {
        CheckDistance(9);
    }

    public override void CheckDistance(int distanceMax)
    {
        float distance = Vector3.Distance(spawnPos,transform.position);
    
        if (distance > distanceMax)// neu vị trí hen tại lớn hơn vị trí đã cho thi sẽ dua dạn vè pool 
        {
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
