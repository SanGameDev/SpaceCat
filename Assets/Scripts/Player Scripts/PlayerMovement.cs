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

    public void OnAsteroid(Transform asteroid)
    {
        /* la gravedad se vuelve 0, en su lugar se aplica una fuerza en direccion al asteroide */
        rb.gravityScale = 0f;
        /* se resta la posicion del player - asteroide, tanto en "x" como en "y" (x_PLY - x_Ast), (y_PLY - y_Ast) para clacular la direccion de la gravedad */
        Vector2 gravityDirection = new Vector2(asteroid.transform.position.x - this.transform.position.x, asteroid.transform.position.y - this.transform.position.y);
        rb.AddForce(gravityDirection * 100); //se aplica una fuerza en la dreccion previamente calculada

        rb.freezeRotation = false; //se activan las rotaciones en z, fuera del asteroide se desactivan

        float ang = Vector2.SignedAngle(Vector2.down, gravityDirection); //la direccion de la gravedad se convierte a angulo
        transform.rotation = (Quaternion.AngleAxis(ang, Vector3.forward)); //se cambia la rotacion del jugador en direccion al planeta

        jumpForce = 40f; //la fuerza del saltro aumenta para poder salir del asteroide (mantener este valor entre 40-50)
    }

    public void OutAsteroid()
    {
        rb.gravityScale = 1f; //vuelve la gravedad
        jumpForce = 2f; //se reduce el salto (cambiar este valor al establecido en el inspector)
        transform.rotation = Quaternion.Euler(0, 0, 0); //se restablece la rotacion a 0 para que el player quede paradito
        rb.freezeRotation = true; //se cancelas las rotaciones en z
    }
    
    
}
