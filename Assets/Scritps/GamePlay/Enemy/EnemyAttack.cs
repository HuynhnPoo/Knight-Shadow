using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected LayerMask playerLM;

   [SerializeField] protected Transform hoderBulletEnemy;
    [SerializeField] protected GameObject bullet;

    protected ObjectPool<Queue<GameObject>> pool;

    protected int size = 50;

    private void OnEnable()
    {
        if (hoderBulletEnemy != null) return;
        hoderBulletEnemy = transform.Find("HoderBulletEnemy");
        pool = new ObjectPool<Queue<GameObject>>(bullet, size, hoderBulletEnemy); //khoi tao pool bullet enemy
       
    }

    //thuc hien danh gan
    public virtual void MeleeAttackPlayer(int dame, float rangeAttack, Vector2 posAttack)
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(posAttack, rangeAttack, playerLM);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponentInChildren<CharacterInfo>().TakeDame(dame);
        }
    }

    public virtual void RangedAttackPlayer(Vector2 posSpawn, Vector2 direction, EnemyStateCrtl enemyStateCrtl)
    {
       
        if (pool == null) return;
        GameObject bullet = pool.GetObject(); // lay bullet ra khoi pool


        if (bullet == null) return;
        bullet.transform.position = posSpawn; // cap nhat vi tri cua bullet

        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {

            enemyBullet.SetEnemyStateCrtl(enemyStateCrtl);// chuyen enemy controll  vào trong enemybullet
            enemyBullet.Move(direction);
            enemyBullet.Init(bullet.transform.position);// 
        }
    }


    public virtual void ReturnToPoolBulletE(GameObject obj)
    {
        pool.ReturnObject(obj);
    }

   
}
