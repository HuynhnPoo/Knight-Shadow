using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitShop : ButtonShop
{
    // Start is called before the first frame update
   protected override void Start()
   {
        base.Start();
   }

    protected override void OnClick()
    {
        OpenShop();
    }
}
