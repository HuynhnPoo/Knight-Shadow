using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationWeapon : MonoBehaviour
{
    [SerializeField] private Animator charcterAni;

    int selectWeapon;
   // [SerializeField] private Animator charcterAni2;
    private void OnEnable()
    {
        /* foreach (Transform child in transform)
         {
             child.gameObject.SetActive(false);
         }*/
    }
    void Update()
    {
        //  int ooo = selectWeapon;

        if (Input.GetKey(KeyCode.Alpha1)) SelectAni(0);
        if (Input.GetKey(KeyCode.Alpha2) && transform.childCount >= 2) SelectAni(1);

    }

    // Start is called before the first frame update
    void Start()
    {
        SelectAni(0);
    }

   public  void WeaponAttack() { charcterAni.SetTrigger("Attack"); }
    // Update is called once per frame
   public  void SelectAni(int selectAni)
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            if (index == selectAni)
            {
                child.gameObject.SetActive(true);
                charcterAni = GetComponentInChildren<Animator>();
            }
            else
            {
                child.gameObject.SetActive(false);
            }
           index++;
        }
    }
   
}
