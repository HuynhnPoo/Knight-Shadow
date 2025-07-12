using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaTxt : TextBase
{
    private void Update()
    {
        if (this.text == null) return;
        this.text.SetText(PotionSave.GetPotionCount("Mana").ToString());
    }
}
