using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
   [SerializeField] private Bullet bullet;
    
    public override void Attacking()
    {
        Bullet();
        Debug.Log("day là cung danh ban");
    }


    // ham sinh dan
    public Bullet Bullet() {

        Bullet bullet=Instantiate(this.bullet,transform.position,Quaternion.identity);
        return bullet;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
