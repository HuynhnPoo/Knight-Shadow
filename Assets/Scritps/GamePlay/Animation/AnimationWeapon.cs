using System.Collections;
using System.Collections.Generic;
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

        if (Input.GetKey(KeyCode.Alpha1)) SelectWeapon(1);
        if (Input.GetKey(KeyCode.Alpha2) && transform.childCount >= 2) SelectWeapon(2);
        if (Input.GetKey(KeyCode.Alpha3) && transform.childCount >= 3) SelectWeapon(3);

    }

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon(0);
    }

   public  void WeaponAttack() { charcterAni.SetTrigger("Attack"); }
    // Update is called once per frame
   public  void SelectWeapon(int SelectWeapon)
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            if (index == SelectWeapon)
            {
                child.gameObject.SetActive(true);
                charcterAni = GetComponentInChildren<Animator>();

                GameManager.Instance.PlayerCrtl.GetcompomentWeaponSelected();
            }
            else
            {
                child.gameObject.SetActive(false);
            }
           index++;
        }
    }
   
}
