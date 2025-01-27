using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    [SerializeField]private Animator charcterAni;

   
    private readonly string MOVE_X="MoveX";
    private readonly string MOVE_Y="MoveY";
    private readonly string IS_MOVE = "Move";
   
    private void Awake()
    {
        if (charcterAni == null)
            charcterAni = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
       
    }
    public void MoveAni(bool isMove, Vector2 direction)
    {

        if (charcterAni == null) return;
        charcterAni.SetBool(IS_MOVE, isMove);

        if (direction.x > 0) charcterAni.SetFloat(MOVE_X, direction.x);
        if (direction.x < 0) charcterAni.SetFloat(MOVE_X, direction.x);
        if (direction.y > 0) charcterAni.SetFloat(MOVE_Y, direction.y);
        if (direction.y < 0) charcterAni.SetFloat(MOVE_Y, direction.y);

    }

    public void AtkAni()
    {
        
    }


}
