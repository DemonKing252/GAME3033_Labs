using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{

    protected override void FireWeapon()
    {
        base.FireWeapon();

        Debug.Log("hello");
        Vector3 hitLocation;

        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder.playerController.isRunning)
        {

            base.FireWeapon();

            Ray screenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;
                Vector3 hitDirection = hit.point - Camera.main.transform.position;
                Debug.DrawRay(Camera.main.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1f);
            }

        }
        else if (weaponStats.bulletsInClip <= 0)
        {

        }
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
