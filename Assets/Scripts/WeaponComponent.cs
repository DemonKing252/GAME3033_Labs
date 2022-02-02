using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    Pistol,
    MachineGun
}
public enum WeaponFiringPattern
{
    SemiAuto,
    FullAuto,
    ThreeShotBurst,
    FiveShotBurst
}
[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public WeaponFiringPattern firingPattern;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayers;
}


public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;
    public WeaponStats weaponStats;
    protected WeaponController weaponHolder;

    public bool isFiring;
    public bool isReloading;


    // Start is called before the first frame update
    void Start()
    {
    }
    public void Init(WeaponController weaponHolder)
    {
        this.weaponHolder = weaponHolder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void StartFiringWeapon()
    {
        isFiring = true;
        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireStartDelay);
        }
        else
        {
            FireWeapon();
        }
    }
    public virtual void StopFiringWeapon()
    {
        CancelInvoke(nameof(FireWeapon));
    }
    protected virtual void FireWeapon()
    {
        Debug.Log("Firing weapon: " + weaponStats.bulletsInClip);
        weaponStats.bulletsInClip--;
        
    }
}
