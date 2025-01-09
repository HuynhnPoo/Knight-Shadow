using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameObjectByNameHide 
{
    private static Dictionary<string, GameObject> gameObjectCache = new Dictionary<string, GameObject>();
    public static GameObject FindGameObjectByName(string name)
    {
        if (gameObjectCache.TryGetValue(name, out GameObject cachedObject))
        { return cachedObject; }
        Transform[] transforms = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in transforms)
        {
            if (t.hideFlags == HideFlags.None && t.name == name)
            {
                gameObjectCache[name] = t.gameObject; return t.gameObject;
            }
        }
        return null;
    }
}
