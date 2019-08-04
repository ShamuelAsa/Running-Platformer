using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _jumpanim;
    public bool isGrounded = true;
    public int _maxJump = 2;
    public int _Jump = 0;
    private Rigidbody2D _rb;

	void Start ()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _jumpanim = gameObject.GetComponent<Animator>();
	}

    void Update()
    {
        if(isGrounded == true)
        {
            _jumpanim.SetBool("Jumping", false);
            
        }
        else
        {
            _jumpanim.SetBool("Jumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _Jump < _maxJump)
        {
            float heightspd = 2.0f;
            if (_Jump == 0)
            {
                _rb.velocity = new Vector2(0.0f, 5.0f * heightspd);
                Debug.Log("Jump!");
                isGrounded = false;
                _Jump++;
            }
            else
            if (_Jump == 1)
            {

                _rb.velocity = new Vector2(0.0f, 5.0f * heightspd);
                Debug.Log("Double Jump!");
                isGrounded = false;
                _Jump++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "G-Plat")
        {
            _Jump = 0;
            isGrounded = true;
        }
    }
}
