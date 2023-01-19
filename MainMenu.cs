using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class MainMenu : MonoBehaviour
{
    [Header("Existing Games Listing"), Space()]
    
    public List<GameState> games = new List<GameState>();
    public GameObject gameSlotPrefab;
    public Transform gameSlotsContainer;

    [Header("New Game Dialogue"), Space()]

    public GameObject inputDialogue;
    public TMP_InputField inputField;

    private void Start()
    {
        HideInput();
        FileManager.InitializeSaveDirectory();
        games = FileManager.GetExistingGames();
        PopulateGamesList();
    }
    private void PopulateGamesList()
    {
        if(games.Count > 0)
        {
            foreach (var save in games)
            {
                var gameSlot = Instantiate(gameSlotPrefab, gameSlotsContainer, false).GetComponent<GameSaveSlot>(); ;
                gameSlot.Populate(save);
            }
        }
    }
    public void ShowInput()
    {
        Debug.Log("Show input dialogue box.");
        inputDialogue.SetActive(true);
    }
    public void HideInput()
    {
        Debug.Log("Hide input dialogue box.");
        inputDialogue.SetActive(false);
        
    }
    public void InputName()
    {
        string input = "";
        input = inputField?.text;
        GameManager.instance.New(input);
    }
}
