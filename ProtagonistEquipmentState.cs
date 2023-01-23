using System;
using UnityEngine;

[Serializable]
public class ProtagonistEquipmentState
{
    [SerializeField] private string head;
    [SerializeField] private string chest;
    [SerializeField] private string legs;
    [SerializeField] private string mainHand;
    [SerializeField] private string offHand;

    public string Head => head;
    public string Chest => chest;
    public string Legs => legs;
    public string MainHand => mainHand;
    public string OffHand => offHand;

    public ProtagonistEquipmentState(ProtagonistEquipment equipment)
    {
        this.head = (equipment.head != null) ? equipment.head.name : "";
        this.chest = (equipment.chest != null) ? equipment.chest.name : "";
        this.legs = (equipment.legs) ? equipment.legs.name : "";
        this.mainHand = (equipment.mainHand != null) ?  equipment.mainHand.name : "";
        this.offHand = (equipment.offHand != null) ? equipment.offHand.name : "";
    }
}