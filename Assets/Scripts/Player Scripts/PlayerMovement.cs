using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;
    public string groundTag;

    private Rigidbody2D rb;
    private bool grounded;

    private int CountDeath;

    private Vector2 checkPointPos;

    public int GetCountDeath
    {
        get
        {
            return CountDeath;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        checkPointPos = transform.position;
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
    
    void Death()
    {
        CountDeath++;
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.velocity = new Vector2(0, 0);
        rb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            checkPointPos = other.transform.position;
        }
        if (other.CompareTag("Death"))
        {
            Death();
        }
    }
}
