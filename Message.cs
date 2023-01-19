using System;
using UnityEngine;
/// <summary>
/// The content shown to the player through a dialogue box.
/// </summary>
[Serializable, Tooltip("The content shown to the player through a dialogue box.")]
public class Message
{
    public Citizen _sender;
    //deletepublic AudioClip _audio;
    public string _dialogueOptionText;
    public string _content;
    public Message[] _messages = new Message[4];
}