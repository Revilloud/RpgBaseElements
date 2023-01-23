using UnityEngine;

/// <summary>
///  Unit of storage dor  and can interact with any of the game's systems.
/// </summary>
[CreateAssetMenu(fileName = "new item", menuName = "New/NewItem")]
public class Item : ScriptableObject
{
    [Header("Item properties")]
    public ItemRole itemRole = ItemRole.TRASH;
    /// <summary>
    /// Icon shown in the UI elements.
    /// </summary>
    public Sprite uiIcon;

    /// <summary>
    /// Item's weight value on the player's inventory.
    /// </summary>
    public float weight;

    /// <summary>
    /// Item's value on the game market.
    /// </summary>
    public int marketValue;

    public virtual void Use()
    {
        NewProtagonist.Instance.UseItem(this);
    }
}