using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="NewEnemyData", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int HP;
    public int Speed;
    public int dame;

    public float rapidAttack;
    public float rangeAttack;

    public bool isBoss;
    public int numberTimesAtk;

}