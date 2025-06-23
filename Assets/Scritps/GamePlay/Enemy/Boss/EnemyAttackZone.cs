using UnityEngine;
using System.Collections;


public class EnemyAttackZone : MonoBehaviour
{
   private int radius = 64;              // Bán kính vòng tròn
  

    private SpriteRenderer spriteRenderer;

    private CircleZone CircleZone;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CircleZone = new CircleZone(spriteRenderer, radius);
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
  
