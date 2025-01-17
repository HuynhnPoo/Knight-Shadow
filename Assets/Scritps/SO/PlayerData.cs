using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="NewPlayerData",menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    public string characterName;
    public float hp;
    public float mp;
    public float speed;
    public int dame;
}
