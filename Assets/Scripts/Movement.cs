using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{


    [SerializeField]
    float walkSpeed = 5f;

    [SerializeField]
    float runSpeed = 5f;

    [SerializeField]
    float jumpForce = 5f;

    [SerializeField]
    float aimSensitivity = 10f;

    PlayerController playerController;
    Animator playerAnim;
    public Transform followTransform;

    public LayerMask groundLayer;
    public Vector3 boxSize;

    // movement references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    Rigidbody rb;

    public readonly int movementXHash = Animator.StringToHash("MoveX");
    public readonly int movementYHash = Animator.StringToHash("MoveY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");
    public readonly int isFiringHash = Animator.StringToHash("isFiring");
    public readonly int isReloadingHash = Animator.StringToHash("isReloading");

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //bool hasCollision = Physics.BoxCast(transform.position + new Vector3(0f, boxSize.y * 0.5f, 0f), boxSize, Vector3.down, Quaternion.identity, 0.1f, groundLayer);

            //if (hasCollision)
            {
                Debug.Log("We have landed.");
                playerAnim.SetBool(isJumpingHash, false);
                playerController.isGrounded = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position + new Vector3(0f, boxSize.y * 0.5f, 0f), boxSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //camera x-axis rotation

        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;

        var angleX = followTransform.transform.localEulerAngles.x;
        var angleY = followTransform.transform.localEulerAngles.y;

        if (angleY > 180f && angleY < 300f)
        {
            angles.y = 300f;
        }

        else if (angleY < 180f && angleY > 70f)
        {
            angles.y = 70f;
        }

        if (angleX > 180f && angleX < 300f)
        {
            angles.x = 300f;
        }

        else if (angleX < 180f && angleX > 70f)
        {
            angles.x = 70f;
        }


        //Debug.Log(angles.ToString());


        followTransform.transform.localEulerAngles = angles;

        transform.rotation = Quaternion.Euler(0f, followTransform.transform.rotation.eulerAngles.y, 0f);
        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0f, 0f);

        if (playerController.isGrounded)
        {
            if (!(inputVector.magnitude > 0))
            {
                moveDirection = Vector3.zero;
            }
            moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

            float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;

            Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

            transform.position += movementDirection;
        }

        // movement directino 

        //bool hasCollision = Physics.BoxCast(transform.position + new Vector3(0f, boxSize.y * 0.5f, 0f), boxSize, Vector3.down, Quaternion.identity, 0.1f, groundLayer);

        //Debug.Log("Collision: " + hasCollision.ToString());
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        //Debug.Log(inputVector.ToString());

        playerAnim.SetFloat(movementXHash, inputVector.x);
        playerAnim.SetFloat(movementYHash, inputVector.y);
    }
    public void OnRun(InputValue value)
    {
        playerController.isRunning = value.isPressed;
        playerAnim.SetBool(isRunningHash, value.isPressed);
        //playerAnim.SetBool(isRunningHash, playerController.isRunning);
    }
    public void OnJump(InputValue value)
    {
        playerController.isJumping = value.isPressed;

        if (playerController.isGrounded)
        {
            playerAnim.SetBool(isJumpingHash, true);
            rb.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
            playerController.isGrounded = false;
        }
    }
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        // if we aim up, down, adjust animations to have
        // a mask that will let us properly animate aim.
        //
    }
    public void OnAim(InputValue value)
    {
        playerController.isAiming = value.isPressed;
    }
    public void OnFire(InputValue value)
    {
        playerController.isFiring = value.isPressed;
        playerAnim.SetBool(isFiringHash, playerController.isFiring);
    }
    public void OnReload(InputValue value)
    {
        //if (playerController.isReloading)
        //    return;

        Debug.Log("reloading . . . " + value.isPressed);
        playerController.isReloading = true;
        playerAnim.SetBool(isReloadingHash, true);

    }

}
