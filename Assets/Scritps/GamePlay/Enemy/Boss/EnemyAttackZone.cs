using UnityEngine;
using System.Collections;


public class EnemyAttackZone : MonoBehaviour
{
   private float radius; // Bán kính vòng tròn
  

    [SerializeField]private SpriteRenderer spriteRenderer;
   [SerializeField] private EnemyStateCrtl enemyCrtl;

    private CircleZone CircleZone;

    private void Awake()
    {
        enemyCrtl = GetComponentInParent<EnemyStateCrtl>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    private void Start()
    {

        radius = enemyCrtl.GetRangedAttack() * 100; // gan gia tri range cho radius
        CircleZone = new CircleZone(spriteRenderer,(int) radius);
        CircleZone.DrawCircle();

        spriteRenderer.enabled = false; 
    }

 
    public void ShowcircleZone()
    {
       spriteRenderer.enabled = true;
      
    }

    public void HideCircleZone()
    {
        spriteRenderer.enabled = false;
    }

}
  
