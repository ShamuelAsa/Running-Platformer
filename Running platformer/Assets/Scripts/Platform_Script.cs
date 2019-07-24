using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public bool touched;

    void Start()
    {
        touched = true;
    }

    void OnCollisionExit2D (Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            touched = false;
        }
    }
}
