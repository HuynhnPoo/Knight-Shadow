using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SldHeathBarBoss : SliderBase
{
    [SerializeField] private EnemyInfo enemyInfo;
    protected override void OnChange(float amount)
    {
        if (Mathf.Abs(slider.value-amount)>0.01f) slider.value = amount;
    }

    private void OnEnable()
    {
         enemyInfo =GetComponentInParent<EnemyInfo>();   
    }

    // Start is called before the first frame update
    protected override void  Start()
    {
        base.Start();

       
        slider.maxValue = enemyInfo.CurrentHeath;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemyInfo.CurrentHeath;
    }
}
