using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    private int selectedCharacterIndex = 0;
    [SerializeField] private GameObject[] characterChild;

    private void Awake()
    {
        SelectedCharacter();
    }


    // ham chon nhan vat
    void SelectedCharacter()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt(StringSave.selectionCharacter);

        characterChild = new GameObject[transform.childCount];
        
        
        // Duyệt qua tất cả các con và thêm vào mảng và tắt nó
        for (int i = 0; i < transform.childCount; i++)
        {
            characterChild[i] = transform.GetChild(i).gameObject;
            characterChild[i].SetActive(false);
        }
        characterChild[selectedCharacterIndex].SetActive(true); // bật nhân vật đã chọn
    }
    
}
