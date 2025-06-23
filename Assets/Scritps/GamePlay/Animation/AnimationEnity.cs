using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnity : MonoBehaviour
{

    [SerializeField] private Animator charcterAni;
    [SerializeField] private AnimationWeapon weapon;

    private const string MOVE_X = "MoveX";
    private const string MOVE_Y = "MoveY";
    private const string IS_MOVE = "Move";

    private void Awake()
    {
        if (charcterAni == null)
            charcterAni = GetComponentInChildren<Animator>();
    }

    public void MoveAni(bool isMove, Vector2 direction)
    {
        if (charcterAni == null) return;
        charcterAni.SetBool(IS_MOVE, isMove);// sẽ dung dang di chuyern sẽ thục hiện blen tree di chuyển 4 hướng

        if (direction.x > 0) charcterAni.SetFloat(MOVE_X, direction.x);
        if (direction.x < 0) charcterAni.SetFloat(MOVE_X, direction.x);
        if (direction.y > 0) charcterAni.SetFloat(MOVE_Y, direction.y);
        if (direction.y < 0) charcterAni.SetFloat(MOVE_Y, direction.y);

    }

    //ham thuc hien attack
    public void AtkAni()
    {
        weapon.WeaponAttack();

    }

    //attack cua boss
    public void AttackBossAni()
    {
        charcterAni.SetTrigger("TrigAtk");
    }
    



}
