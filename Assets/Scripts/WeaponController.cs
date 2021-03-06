using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [Header("WeaponToSpawn"), SerializeField]
    GameObject weaponToSpawn;

    public Sprite crossHairImage;

    [SerializeField]
    GameObject weaponSocketLocation;

    public PlayerController playerController;
    public Animator playerAnim;

    [SerializeField]
    Transform gripSocketLoc;

    private bool firingPressed;

    public WeaponHolder weapon;
    public GameObject weaponGO;

    public readonly int movementXHash = Animator.StringToHash("MoveX");
    public readonly int movementYHash = Animator.StringToHash("MoveY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");
    public readonly int isFiringHash = Animator.StringToHash("isFiring");
    public readonly int isReloadingHash = Animator.StringToHash("isReloading");

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {

        weaponGO = Instantiate(
            weaponToSpawn,
            weaponSocketLocation.transform.position,
            weaponSocketLocation.transform.rotation,
            weaponSocketLocation.transform);

        weapon = weaponGO.GetComponent<WeaponHolder>();

        GetComponent<CharacterAimController>().laserFrom = weaponGO.GetComponent<AK47Component>().gripLocation;

        gripSocketLoc = weapon.gripLocation;
        weapon.Init(this);

        PlayerEvents.InvokeOnWeaponEquipped(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (playerController.isReloading)
        {
            playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            return;
        }

        playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        playerAnim.SetIKPosition(AvatarIKGoal.LeftHand, gripSocketLoc.position);
    }

    public void OnAim(InputValue value)
    {
        playerController.isAiming = value.isPressed;
    }
    public void OnFire(InputValue value)
    {
        playerController.isFiring = value.isPressed;
        playerAnim.SetBool(isFiringHash, playerController.isFiring);

        if (value.isPressed)
        {

            playerController.isFiring = true;
            weapon.StartFiringWeapon();
        }
        else
        {
            playerController.isFiring = false;
            weapon.StopFiringWeapon();
        }
    }


    public void OnReload(InputValue value)
    {
        //if (playerController.isReloading)
        //    return;

        Debug.Log("reloading . . . " + value.isPressed);
        playerController.isReloading = true;
        weapon.StartReloading();

    }
}
