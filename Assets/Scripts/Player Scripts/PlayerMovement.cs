using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;
    public string groundTag;

    private Rigidbody2D rb;
    private bool grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * transform.right * movementSpeed);
        
        if (Input.GetAxis("Jump") == 1f && grounded)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    IEnumerator JumpCoroutine()
    {
        rb.AddForce(transform.up * jumpForce);

        yield return new WaitForSeconds(0.05f);

        grounded = false;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(groundTag))
        {
            grounded = true;
        }
    }
}
