using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text weaponNameText;

    [SerializeField] private TMP_Text currentBulletCountText;
    [SerializeField] private TMP_Text totalBulletCountText;

    [SerializeField] WeaponController weaponController;

    private void OnEnable()
    {
        PlayerEvents.onWeaponEquippedDelegate += OnWeaponEquipped;
    }
    private void OnDisable()
    {
        PlayerEvents.onWeaponEquippedDelegate -= OnWeaponEquipped;
    }
    void OnWeaponEquipped(WeaponController weaponController)
    {
        this.weaponController = weaponController;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!weaponController)
            return;

        weaponNameText.text = weaponController.weapon.weaponStats.weaponName;
        currentBulletCountText.text = weaponController.weapon.weaponStats.bulletsInClip.ToString();
        totalBulletCountText.text = weaponController.weapon.weaponStats.totalBullets.ToString();
    }
}
