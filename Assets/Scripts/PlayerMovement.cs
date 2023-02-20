using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float turnsmoothtime = 0.1f;
    public Transform cam;
    float turnsmoothvelocity;
    Rigidbody rb;
    Animator anim;
    private bool IsJumping;
    private bool IsGrounded;
   
    [SerializeField] float movementspeed = 6f;
    [SerializeField] float jumpforce = 5f;

   [SerializeField] Transform groundCheck;

   [SerializeField] LayerMask Ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalinput = Input.GetAxisRaw("Vertical");
        float horizontalimput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalimput, 0f, verticalinput);
        
        rb.velocity = new Vector3(horizontalimput * 5f, rb.velocity.y, verticalinput * 5f);
        
        if (direction.magnitude >= 0.1f)
        {
          float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
          float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnsmoothtime);
          transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if(Input.GetButtonDown("Jump") && Grounded())
        {
          rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);
          anim.SetBool("IsJumping", true);
        }
    }   
    private bool Grounded()
    {
      IsGrounded = true;
      IsJumping = false;
      return Physics.CheckSphere(groundCheck.position, 0.1f, Ground);
    }
      
}
