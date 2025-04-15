using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SldLevel : SliderBase
{
    protected override void OnChange(float amount) => slider.value = amount;
    

    private void Update()
    {
        OnChange(GameManager.Instance.CurrentExperice);
        slider.maxValue =GameManager.Instance.MaxExperice;
    }
}
