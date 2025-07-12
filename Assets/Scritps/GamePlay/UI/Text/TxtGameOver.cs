using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtGameOver : TextBase
{
    string textGameOver;
    private void Update()
    {

        if (GameManager.Instance.IsGameOver)
        {
            textGameOver = "Game Over!";
            UpdateText(textGameOver);
        }
        else if (GameManager.Instance.IsWinGame)
        {
            textGameOver = "Win Game!";
            UpdateText(textGameOver);

        }
    }
    void UpdateText(string text)
    {
        this.text.SetText(text);
        Debug.Log(text);
    }
}
