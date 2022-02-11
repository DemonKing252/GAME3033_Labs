using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedDelegate(WeaponController weaponController);
    public static event OnWeaponEquippedDelegate onWeaponEquippedDelegate;

    public static void InvokeOnWeaponEquipped(WeaponController weaponController)
    {
        onWeaponEquippedDelegate?.Invoke(weaponController);
    }
    
}
