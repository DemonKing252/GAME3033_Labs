using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponHolder
{
    Vector3 hitLocation;
    protected override void FireWeapon()
    {
        base.FireWeapon();


        if (weaponStats.bulletsInClip > 0 && !weaponHolder.playerController.isReloading && !weaponHolder.playerController.isRunning)
        {
            weaponStats.bulletsInClip--;


            print("should fire");
            firingEffect.Play();

            //Debug.Log("Firing weapon: " + weaponStats.bulletsInClip + "/" + weaponStats.totalBullets);

            Ray screenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;
                DealDamge(hit);
                Vector3 hitDirection = hit.point - Camera.main.transform.position;
                Debug.DrawRay(Camera.main.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1f);
            }

        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            Debug.Log("my pants are down");
            StartReloading();
        }
    }
    void DealDamge(RaycastHit hitInfo)
    {
        hitInfo.transform.GetComponent<HealthComponent>().TakeDamage(weaponStats.damage);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitLocation, 0.1f);
    }

    public override void StartReloading()
    {
        base.StartReloading();

        weaponHolder.playerAnim.SetBool("isReloading", true);

        int bulletsToReload = weaponStats.clipSize - weaponStats.totalBullets;
        if (bulletsToReload < 0)
        {
            weaponStats.totalBullets -= (weaponStats.clipSize - weaponStats.bulletsInClip);
            weaponStats.bulletsInClip = weaponStats.clipSize;
        }
        else
        {
            weaponStats.bulletsInClip = weaponStats.totalBullets;
            weaponStats.totalBullets = 0;
        }

    }
    public override void StopReloading()
    {
        base.StopReloading();

    }

    public override void StartFiringWeapon()
    {
        if (weaponHolder.playerController.isReloading)
            return;

        base.StartFiringWeapon();

        isFiring = true;
        if (weaponStats.repeating)
        {
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }

    }
    public override void StopFiringWeapon()
    {
        base.StopFiringWeapon();

        if (firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }


        CancelInvoke(nameof(FireWeapon));

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
