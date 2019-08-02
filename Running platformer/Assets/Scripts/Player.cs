using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded = true;
    public int _maxJump = 2;
    public int _Jump = 0;
    private Rigidbody2D _rb;

	void Start ()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();	
	}

	void Update ()
    {

        float heightspd = 50.0f;
		if(Input.GetKeyDown(KeyCode.Space) && _Jump < _maxJump)
        {
            if(_Jump == 0)
            {
                _rb.AddForce(new Vector2(0, 8.0f * heightspd));
                Debug.Log("Jump!");
                _Jump++;
            }
            else
            if(_Jump == 1)
            {
                _rb.AddForce(new Vector2(0, 5.0f * heightspd));
                Debug.Log("Double Jump!");
                _Jump++;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "G-Plat")
        {
            _Jump = 0;
        }
    }
}
