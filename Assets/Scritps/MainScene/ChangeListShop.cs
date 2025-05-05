using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeListShop : MonoBehaviour
{
   [SerializeField] private GameObject[] listChracter;
    int currentIndex = 0;


    private void Awake()
    {
        listChracter=new GameObject[transform.childCount];
        int index = 0;
        foreach (Transform child in transform)
        {
            listChracter[index]=child.gameObject;
            listChracter[index].SetActive(false);
            index++;
        }

        listChracter[0].SetActive(true);
    }
    // di chuyen len
    public void ChangeShopNext()
    {
        listChracter[currentIndex].SetActive(false);
        currentIndex++;

        if (currentIndex >= listChracter.Length) currentIndex = 0;

        listChracter[currentIndex].SetActive(true);
    }
    

    // quay nguoc lai
   public  void ChangeShopPrevious()
    {
        listChracter[currentIndex].SetActive(false);

        currentIndex--;
        if (currentIndex <= -1) currentIndex = listChracter.Length - 1;


        listChracter[currentIndex].SetActive(true);

    }
}
