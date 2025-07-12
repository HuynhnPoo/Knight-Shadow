using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathTxt :TextBase
{
    private void Update()
    {
        if (this.text==null) return;
         this.text.SetText(PotionSave.GetPotionCount("Heath").ToString());
    }
}
