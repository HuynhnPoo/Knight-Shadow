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
        GameObject bullet = pool.GetObject();
        if (bullet == null) return;
        bullet.transform.position = posSpawn;

        EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {

            enemyBullet.EnemyStateCrtl(enemyStateCrtl);
            enemyBullet.Move(direction);
        }
    }

    public void ReturnToPoolBulletE(GameObject obj)
    {
        pool.ReturnObject(obj);
    }
}
