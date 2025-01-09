using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="NewPlayerData",menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    public new string name;
    public float hp;
    public float mp;
    public float speed;
    public float dame;
}
