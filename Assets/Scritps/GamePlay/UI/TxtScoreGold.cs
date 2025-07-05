using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtScoreGold : TextBase
{
    private void Update()
    {
        if (text ==null) return;
        text.SetText(GameManager.Instance.TotalGold.ToString("D6"));
    }
}
