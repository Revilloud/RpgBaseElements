using System;
using UnityEngine;

/// <summary>
/// Content shown to the player on the interaction and the system's answer.
/// </summary>
[Serializable]
public abstract class Interactable : MonoBehaviour
{
    public int id;
    public string actionVerb;
    public float maximumUseDistance;
    public AudioClip sound;

    private void Awake()
    {
        id = GetInstanceID();
    }
    public void Interact()
    {

    }

    public string TextoMirar()
    {
        return "";
    }
}