using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    [SerializeField] private GameObject bullet2;
    [SerializeField] private ObjectPool<Stack<GameObject>> pool2;
    [SerializeField] private EnemyAttackZone zone;
    private void OnEnable()
    {
        size = 20;
        if (hoderBulletEnemy == null)
            hoderBulletEnemy = transform.Find("HoderBulletBoss");
     
       

        pool = new ObjectPool<Queue<GameObject>>(bullet, size, hoderBulletEnemy); //khoi tao pool bullet enemy
        pool2 = new ObjectPool<Stack<GameObject>>(bullet2, size, hoderBulletEnemy); //khoi tao pool bullet enemy   
       
       
    }

    private void Start()
    {
    }

    public  void SpawningCircle(Vector2 posSpawn, int bulletCount, EnemyStateCrtl enemyStateCrtl)
    {
        float angleStep = 360 / bulletCount;
        float angle = 0;
        for (int i = 0; i < bulletCount; i++)
        {
            float dirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float dirY = Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector2 direction = new Vector2(dirX, dirY).normalized;

            GameObject obj = pool2.GetObject();
            obj.transform.position = posSpawn;
            obj.transform.rotation = Quaternion.identity;


            BossBulletSkill bullet = obj.GetComponent<BossBulletSkill>();

            if (bullet != null)
            {
                bullet.SetEnemyStateCrt(enemyStateCrtl);
                bullet.Move(direction);
                bullet.Init(bullet.transform.position);
            }
            angle += angleStep;
        }
    }

    public IEnumerator ExecuteSkillOfBoss(EnemyStateCrtl enemy, float skillDuration, float damageInterval, float elapsedTime)
    {
        zone = GetComponentInChildren<EnemyAttackZone>();
        zone.ShowcircleZone();// bat vung canh báo

        yield return new WaitForSeconds(0.5f);
        if (enemy.GetNameEnemy() != "Rider_Boss")
            enemy.SkillBoss.gameObject.SetActive(true); //sau 0.5 s sẽ bật skill

        while (elapsedTime < skillDuration) // thoi gian thuc hien tan công cua skill
        {
            float distanceeEnemy = enemy.GetDistanceEnemy();
            float distanceMax = enemy.GetRangedAttack() + 2;
            if (distanceeEnemy < distanceMax)
            {
                Debug.Log("hien thi ra "+enemy);
                if (enemy.GetNameEnemy() == "Rider_Boss") SpawningCircle(enemy.transform.position,8,enemy);
                MeleeAttackPlayer(enemy.GetDameOfEnemy(), distanceMax, enemy.transform.position);
            }
            yield return new WaitForSeconds(damageInterval);
            elapsedTime += damageInterval;

        }

        // phân tắt hêt skill và vung canh bao
        if (enemy.GetNameEnemy() != "Rider_Boss")
            enemy.SkillBoss.gameObject.SetActive(false);
        zone.HideCircleZone();

    }

}
