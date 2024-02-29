using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGRavity : MonoBehaviour
{
    public float gravity = -10f;
    public float jumpForceMultiplier;
    public Vector3 directionUp;

    public void GravityDirection(Transform body)
    {
        body.GetComponent<PlayerMovement>().jumpForceMultiplier = jumpForceMultiplier;
        
        Vector3 gravityUp = directionUp;
        Vector3 bodyUp = body.up;
        body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
