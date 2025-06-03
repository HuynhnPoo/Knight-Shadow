using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private LayerMask playerLM;

    private Transform hoderBulletEnemy;
    [SerializeField] private GameObject bullet;
    private ObjectPool<Queue<GameObject>> pool;
    private int size = 50;

    private void OnEnable()
    {
        if (hoderBulletEnemy != null) return;
        hoderBulletEnemy = transform.Find("HoderBulletEnemy");

        pool = new ObjectPool<Queue<GameObject>>(bullet, size, hoderBulletEnemy);
    }


    //thuc hien danhga
    public void MeleeAttackPlayer(int dame, float rangeAttack, Vector2 posAttack)
    {

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(posAttack, rangeAttack, playerLM);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponentInChildren<CharacterInfo>().TakeDame(dame);
        }
    }

    public void RangedAttackPlayer(Vector2 posSpawn, Vector2 direction, EnemyStateCrtl enemyStateCrtl)
    {

        if (pool == null) return;
        GameObject bullet = pool.GetObject(); // lay bullet ra khoi pool


        if (bullet == null) return;
        bullet.transform.position = posSpawn; // cap nhat vi tri cua bullet

        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {

            enemyBullet.SetEnemyStateCrtl(enemyStateCrtl);
            enemyBullet.Move(direction);
            enemyBullet.Init(bullet.transform.position);
        }
    }

    public void ReturnToPoolBulletE(GameObject obj)
    {
        pool.ReturnObject(obj);
    }
}
