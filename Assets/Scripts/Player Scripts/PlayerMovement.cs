using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * movementSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * movementSpeed);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    
    
}
