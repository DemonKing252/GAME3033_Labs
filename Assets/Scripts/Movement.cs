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

    PlayerController playerController;
    Animator playerAnim;


    // movement references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;

    Rigidbody rb;

    public readonly int movementXHash = Animator.StringToHash("MoveX");
    public readonly int movementYHash = Animator.StringToHash("MoveY");
    public readonly int isJumpingHash = Animator.StringToHash("isJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");

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
            Debug.Log("We have landed.");
            playerAnim.SetBool(isJumpingHash, false);
            playerController.isGrounded = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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


}
