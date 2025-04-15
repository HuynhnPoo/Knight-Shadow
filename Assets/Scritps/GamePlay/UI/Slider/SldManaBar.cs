using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SldManaBar : SliderBase
{
    protected override void OnChange(float amount) => slider.value=amount;


    protected override void Start()
    {
        base.Start();
        slider.maxValue =GameManager.Instance.PlayerCrtl.CharacterInfo.Mana;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.PlayerCrtl.CharacterInfo.Mana; 
    }

   
}
