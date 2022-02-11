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
    public int totalBullets;
}


public class WeaponHolder : MonoBehaviour
{
    public Animator playerAnimator;
    public Transform gripLocation;
    public WeaponStats weaponStats;
    protected WeaponController weaponHolder;

    [SerializeField]
    protected ParticleSystem firingEffect;
    public bool isFiring;
    //public bool isReloading;


    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        //firingEffect = GetComponentInChildren<ParticleSystem>();
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
        
    }
    public virtual void StopFiringWeapon()
    {
    }
    protected virtual void FireWeapon()
    {
        
    }

    public virtual void StartReloading()
    {
        weaponHolder.playerController.isReloading = true;

    }
    public virtual void StopReloading()
    {
        weaponHolder.playerController.isReloading = false;
        //if (playerAnimator.GetBool("IsReloading")) return;
        //playerAnimator.SetBool("IsReloading", false);
        
    }
}
