using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float jumpForce = 45.0f;
    public string groundTag = "Ground";
    private Rigidbody2D rb;
    [SerializeField] private bool grounded;
    public float speed = 7.0f;
    

    [Header("Gravity")]
    public FauxGravityAttractor attractor;
    public ChangeGRavity changeGRavity;

    [Space(10)]

    private Transform myTransform;
    public float jumpForceMultiplier;

    [Space(10)]


    [Header("Get Count Death")]
    private int CountDeath;
    public int GetCountDeath { get { return CountDeath; } }
    private Vector2 checkPointPos;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkPointPos = transform.position;
        myTransform = transform;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");

        if(moveHorizontal != 0)
        {
            transform.localScale = new Vector2(moveHorizontal, 1);
            Vector3 movement;
            if (attractor)
            {
                movement = new Vector3 (moveHorizontal, 0.0f, 0) * speed * Time.deltaTime;

                transform.Translate(movement);
            }
            else
            {
                movement = transform.right * speed * moveHorizontal;

                rb.velocity = new Vector2(movement.x, rb.velocity.y);
            }
        }

        if (Input.GetAxis("Jump") > 0.5 && grounded)
        {
            StartCoroutine(JumpCoroutine());
        }

        GravityController();
    }

    private void FixedUpdate()
    {
        bool acelerated = false;
        if(!grounded && !acelerated)
        {
            rb.AddForce(new Vector2(0, -8));
            acelerated = true;
        }
        else
        {
            acelerated = false;
        }
    }

    void GravityController()
    {
        if(attractor != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0;
            attractor.Attract(transform);
        }else if(changeGRavity != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0;
            changeGRavity.GravityDirection(transform);
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
            rb.AddForce(transform.up * jumpForce * jumpForceMultiplier);
            yield return new WaitForSeconds(0.05f);
            grounded = false;
            attractor = null;
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
        switch (other.tag)
        {
            case "Death":
                Death();
                break;
            case "CheckPoint":
                checkPointPos = other.transform.position;
                break;
            case "Planet":
                attractor = other.GetComponent<FauxGravityAttractor>();
                break;
            case "Gravity":
                changeGRavity = other.GetComponent<ChangeGRavity>();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Gravity"))
        {
            changeGRavity = null;
        }
    }
}
