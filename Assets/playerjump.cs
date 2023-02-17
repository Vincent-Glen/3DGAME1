using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjump : MonoBehaviour
{
    public Rigidbody rb;
    public bool cubeisontheground;

    
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if(Input.GetButtonDown("Jump") && cubeisontheground)
        { 
           rb.AddForce(new Vector3(), ForceMode.Impulse);   
           cubeisontheground = false;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == ("rain_path_01aain_path_01a"))
        {
            cubeisontheground = true;   
        }
    }
}
