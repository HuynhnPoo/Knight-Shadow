using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SldHeathBar : SliderBase
{
    protected override void OnChange(float amount)=> slider.value= amount;

    protected override void Start()
    {
        base.Start();
        slider.maxValue = GameManager.Instance.PlayerCrtl.CharacterInfo.Heath;
    }

    private void Update()
    {
      
        slider.value= GameManager.Instance.PlayerCrtl.CharacterInfo.Heath;
    }
}
