using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float rotationspeed = 10f;
    [SerializeField] private Camera followcamera;
     Rigidbody rb;
     Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]  private float jumpHeight = 5f;
    [SerializeField]  private float gravityValue = -9.81f;
     private bool IsJumping;    
    private bool IsGrounded;
   [SerializeField] Transform groundCheck;  
   [SerializeField] LayerMask Ground;

     

    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      rb = GetComponent<Rigidbody>();

     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        movement();

        if (Input.GetKey("w"))
        {
          anim.SetBool("IsMovingForward", true);
        }
        else
        {
          anim.SetBool("IsMovingForward", false);
        }      

        if (Input.GetKey("s"))
        {
          anim.SetBool("IsMovingBackwards", true);
        }
        else
        {
          anim.SetBool("IsMovingBackwards", false);
        }
        
        if (Input.GetKey("d"))
        {
          anim.SetBool("IsMovingRight", true);
        }
        else
        {
          anim.SetBool("IsMovingRight", false);
        }

        if (Input.GetKey("a"))
        {
          anim.SetBool("IsMovingLeft", true);
        }
        else

        {
          anim.SetBool("IsMovingLeft", false);
        }

        if (Input.GetKeyDown("space"))
        {
          anim.SetBool("IsJumping", true);
          IsJumping = true;
        }
        else
        {
          anim.SetBool("IsJumping", false);
        }

        
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * 5f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }   
    private bool Grounded()
    {
      anim.SetBool("IsGrounded", true);
      IsGrounded = true;
      IsJumping = false;
      return Physics.CheckSphere(groundCheck.position, 0.1f, Ground);
    }
    void movement()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) 
        {
            playerVelocity.y = 0f;
        }

        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis ("Vertical");

        Vector3 movementInput = Quaternion.Euler(0,followcamera.transform.eulerAngles.y,0) * new Vector3(horizontalinput, 0, verticalinput);
        Vector3 movementdirection = movementInput.normalized;

        controller.Move(movementdirection * playerspeed * Time.deltaTime);

        if (movementdirection != Vector3.zero)
        {
            Quaternion desiredrotation = Quaternion.LookRotation(movementdirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredrotation, rotationspeed*Time.deltaTime );
        }

           if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

