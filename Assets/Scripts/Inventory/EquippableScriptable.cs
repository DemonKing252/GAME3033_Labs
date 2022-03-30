using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquippableScriptable : ItemScript
{
    private bool isEquipped = false;
    public bool Equipped
    {
        get => isEquipped;
        set
        {
            isEquipped = value;
            onEquipStatusChanged?.Invoke();
        }
    }


    public delegate void EquipStatusChanged();
    public event EquipStatusChanged onEquipStatusChanged;

    public override void UseItem(PlayerController playerController)
    {
        isEquipped = !isEquipped;
    }
}
