using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    None,
    Weapon,
    Consumable,
    Equipment,
    Ammo
    
}


public abstract class ItemScript : ScriptableObject
{
    public string name = "Item";
    public ItemCategory itemCategory = ItemCategory.None;
    public GameObject itemPrefab;
    public bool stackable;
    public int maxSize = 1;

    public delegate void AmountChange();
    public event AmountChange onAmountChanged;

    public delegate void ItemDestroyed();
    public event ItemDestroyed onItemDestroyed;

    public delegate void ItemDropped();
    public event ItemDropped onItemDropped;

    public int amountValue = 1;

    public PlayerController controller { get; private set; }

    public virtual void Initialize(PlayerController playerController)
    {
        controller = playerController;
    }
    public abstract void UseItem(PlayerController playerController);
    
    public virtual void DeleteItem(PlayerController playerController)
    {
        onItemDestroyed?.Invoke();
        // Delete item from inventory system
    }
    public virtual void DropItem(PlayerController playerController)
    {
        onItemDropped?.Invoke();
    }
    public void ChangeAmount(int amount)
    {
        amountValue += amount;
        onAmountChanged?.Invoke();
    }
    public void SetAmount(int amount)
    {
        amountValue = amount;
        onAmountChanged?.Invoke();
    }


}
