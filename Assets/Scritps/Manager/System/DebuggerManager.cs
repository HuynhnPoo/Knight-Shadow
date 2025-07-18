using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerManager : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
         Debug.unityLogger.logEnabled = false;
#endif
    }
}
