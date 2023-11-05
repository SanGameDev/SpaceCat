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

    private Rigidbody2D rb;

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
        checkPointPos = transform.position;
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
