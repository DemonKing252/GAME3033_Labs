using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 1)]
public class Consumable : ItemScript
{
    public int effect = 0;
    public override void UseItem(PlayerController playerController)
    {
        // Check if the player is at max health, then return
        // Heal player with potion

        SetAmount(amountValue - 1);
        
        if (amountValue <= 0)
        {
            DeleteItem(playerController);
        }
    }

}
