using System;
using UnityEngine;

/// <summary>
/// Content shown to the player on the interaction and the system's answer.
/// </summary>
[Serializable]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private string actionVerb;
    [SerializeField] private float maximumUseDistance;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        id = GetInstanceID();
    }
    public void Interact()
    {
        PlayAudioClip(audioClip);
    }

    public string TextoMirar()
    {
        return $"[{actionVerb}] [{name}]";
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        if (audioClip == null) return;
        audioSource.PlayOneShot(audioClip, 1f);
    }
}