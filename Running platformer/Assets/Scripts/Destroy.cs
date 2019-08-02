using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
