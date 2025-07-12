using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtLevelVsExp : TextBase
{
    // Update is called once per frame
    void Update()
    {
        if (text == null) return;
        string currentLevel = GameManager.Instance.CurrentLevel.ToString("D2");
        string currentExperice = GameManager.Instance.CurrentExperice.ToString("D4");
        string maxExperice = GameManager.Instance.MaxExperice.ToString("D4");
        text.SetText("Level:" + currentLevel + "\t" + currentExperice + "/" + maxExperice);
    }
}
