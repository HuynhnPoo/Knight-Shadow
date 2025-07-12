using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitGameButton : ButtonBase
{
    protected override void OnClick()
    {
        SoundManager.Instance.PlaySfx(TagInGame.buttonClick);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity 
#endif
    }

}
