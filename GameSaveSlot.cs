using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSaveSlot : MonoBehaviour
{
    [Header("UI Elements"), Space()]
    public GameState saveState;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dateText;

    public void Populate(GameState state)
    {
        this.saveState = state;
        transform.name = state.GameName;
        nameText.text = transform.name;
        dateText.text = state.UpdateTime;
    }

    public void Click_Button()
    {
        GameManager.instance.Load(saveState);
    }
}
