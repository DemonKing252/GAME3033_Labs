using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float health = 100f;
    public TMP_Text healthText;

    public float Health
    {
        get { return health; }
        set { health = value; healthText.text = "Health: " + health.ToString() + "%"; }
    }

    public bool isFiring;
    public bool isReloading;
    public bool isJumping;
    public bool isRunning;
    public bool isGrounded;
    public bool isAiming;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
