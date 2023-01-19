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

    public void Populate(GameState saveState)
    {
        this.saveState = saveState;
        transform.name = saveState.player.name;
        nameText.text = transform.name;
        dateText.text = saveState.updateTime;
    }

    public void Click_Button()
    {
        GameManager.instance.Load(saveState);
    }
}
