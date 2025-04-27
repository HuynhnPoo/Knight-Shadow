using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(CharacterInfo))]
public class CharactorSelector : MonoBehaviour
{
    [SerializeField] private  Button[] characterButtons;
    public int selectedCharacterIndex = 0;

    void Start()
    {

        characterButtons= GetComponentsInChildren<Button>();  
        // Load the last selected character from PlayerPrefs
        selectedCharacterIndex = PlayerPrefs.GetInt(StringSave.selectionCharacter, 0);
        UpdateButtonSelection();
    }
                                        
    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;
        PlayerPrefs.SetInt(StringSave.selectionCharacter, selectedCharacterIndex);
        UpdateButtonSelection();
    }

/*
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene"); // Replace with your main game scene name
    }*/
    void UpdateButtonSelection()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            characterButtons[i].interactable = i != selectedCharacterIndex;
        }
    }


}
