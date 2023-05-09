using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float hareketHizi = 6.0f;
    public float ziplamaYuksekligi = 5.0f;
    public Transform groundCheck;
    public LayerMask ground;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity= new Vector3(horizontalInput*hareketHizi, rb.velocity.y,verticalInput*hareketHizi);
        if (Input.GetButtonDown("Jump") && isGrounded()) 
        { 
            rb.velocity= new Vector3(rb.velocity.x,ziplamaYuksekligi,rb.velocity.z);
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
