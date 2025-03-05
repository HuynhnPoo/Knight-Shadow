using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float rangeAttack=5;
    [SerializeField] private int dameWeapon=1;
    [SerializeField] private LayerMask enemy;

    public override void Attacking()
    {
        // khoi tao pham vi danh quai
        Collider2D[] hitEnemis = Physics2D.OverlapCircleAll(this.transform.position, rangeAttack, enemy);

        foreach (Collider2D enemies in hitEnemis)
        {
            Debug.LogWarning("hien thi enemy" + enemies.name);
            //mỗi lần va chạm sẽ giảm máu quái vật

            int dame = GameManager.Instance.PlayerCrtl.DameAttack() + dameWeapon;
            enemies.GetComponent<EnemyInfo>().TakeDame(dame);
        }

        Debug.Log("day là kiem dang đanh");
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnDrawGizmosSelected()
    {
       Gizmos.DrawWireSphere(this.transform.position, rangeAttack);
    }
}
