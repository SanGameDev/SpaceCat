using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayout : MonoBehaviour
{
    public GameManage gameManage;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            gameManage.ChangeLevelLayout();
        }
    }
}
