using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public Player _playerS;

    void Start()
    {
        _playerS = GameObject.Find("Player").gameObject.GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "HeadCol")
        {
            _playerS.isGrounded();
            Debug.Log("Cannot Jump!");
        }
    }
}
