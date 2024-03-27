using UnityEngine;

public class FolowPlayer : MonoBehaviour
{
    //GameObject que será el objetivo de la camara, este será un objeto llamado Follow colocado en el player
    public GameObject target;
    //Guarda la posicion del target
    Vector2 target_pos;

    float posX;
    float posY;

    //Establecen los limites del movimiento de la camara hacia la izquierda o derecha
    public float xRightLimit;
    public float xLeftLimit;

    //Establecen los limites del movimiento de la camara hacia arriba y abajo
    public float yUpLimit;
    public float yDownLimit;

    //La velocidad a la que se mueve la camara
    public float speed;
    //Un booleano que permite el movimiento de la camara, en caso de que se requiera que se mueva de otra manera
    public bool scriptOn = true;

    void Awake()
    {
        posX = target_pos.x + xLeftLimit;
        posY = target_pos.y + yDownLimit;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), 1);
    }

    private void Start()
    {
        Invoke("SearchPlayer", 0.1f);
    }

    void SearchPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    void MoveCam()
    {
        if (!scriptOn)
            return;
        
        target_pos.x = target.transform.position.x;
        target_pos.y = target.transform.position.y;
        //Condicionales que, cuando se cumplen, establecen la posicion a la que tiene que moverse la camara tanto en X como en Y
        if (target_pos.x > xLeftLimit && target_pos.x < xRightLimit)
        {
            posX = target_pos.x;
        }

        if (target_pos.y > yDownLimit && target_pos.y < yUpLimit)
        {
            posY = target_pos.y;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);
    }

    void Update()
    {
        //Si target no tiene ningun objeto asignado, no se ejecuta MoveCam()
        if (!target)
            return;
        MoveCam();
    }
}