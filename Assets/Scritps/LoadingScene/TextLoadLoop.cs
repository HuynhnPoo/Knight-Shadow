using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoadLoop : TextBase
{
  
    // Start is called before the first frame update
    protected override  void Start()
    {
        StartCoroutine(LoopText());
    }

   
    IEnumerator LoopText()
    {
        while (true)
        {
            text.text = "loading";
            yield return new WaitForSeconds(0.2f);
            text.text = "loading..";
            yield return new WaitForSeconds(0.2f);
            text.text = "loading....";
            yield return new WaitForSeconds(0.2f);

        }

    }
}
