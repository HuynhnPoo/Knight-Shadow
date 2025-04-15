using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtCoinShop : TextBase
{ 
    // Update is called once per frame
    void Update()
    {
        int goldSave = PlayerPrefs.GetInt("GoldSave");
        Debug.Log(goldSave);
        text.SetText(goldSave.ToString());

    }
}