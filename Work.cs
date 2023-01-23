using System;
/// <summary>
/// A unit of work that may or not require items to start; 
/// after some time passes it will produce an assortment of items.
/// </summary>
public class Work
{
    public DateTime start;
    public DateTime end;
    public float durationSeconds;
    public ProtagonistInventorySlot[] requirements;
    public ProtagonistInventorySlot[] products;
}