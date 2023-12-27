using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce;
    public string groundTag;
    private Rigidbody2D rb;
    [SerializeField] private bool grounded;
    public float speed = 5.0f;
    
    [Header("Faux Gravity")]
    public FauxGravityAttractor attractor;
    private Transform myTransform;

    [Header("Get Count Death")]
    private int CountDeath;
    public int GetCountDeath { get { return CountDeath; } }

    private Vector2 checkPointPos;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //grounded = false;
        checkPointPos = transform.position;
        myTransform = transform;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0) * speed * Time.deltaTime;

        transform.Translate(movement);

        if (Input.GetAxis("Jump") > 0.5 && grounded)
        {
            StartCoroutine(JumpCoroutine());
        }

        if(attractor != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0;
            attractor.Attract(transform);  
        }else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.gravityScale = 1;
        }
    }

    IEnumerator JumpCoroutine()
    {
        if(attractor != null)
        {
            rb.AddForce(transform.up * jumpForce * 2);
            yield return new WaitForSeconds(0.05f);
            grounded = false;
        }
        else
        {
            rb.AddForce(transform.up * jumpForce);
            yield return new WaitForSeconds(0.05f);
            grounded = false;
        }
    }
    
    void Death()
    {
        CountDeath++;
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    { 
        yield return new WaitForSeconds(duration);
        transform.position = checkPointPos;
        transform.localScale = new Vector3(1, 1, 1);
        rb.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(groundTag))
        {
            grounded = true;
        }
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
        if (other.CompareTag("Planet"))
        {
            attractor = other.GetComponent<FauxGravityAttractor>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Planet"))
        {
            attractor = null;
        }
    }
}
