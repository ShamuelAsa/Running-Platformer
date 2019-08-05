using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _Anim;
    public bool isGrounded = true;
    public int _maxJump = 2;
    public int _Jump = 0;
    private Rigidbody2D _rb;
    private GameObject _attackcollider;
	void Start ()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponent<Animator>();
        _attackcollider = GameObject.Find("AttackCollision");
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
        }

        if(isGrounded == true)
        {
            _Anim.SetBool("Jumping", false);
            
        }
        else if(_Jump == 1)
        {
            _Anim.SetBool("Jumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _Jump < _maxJump)
        {
            float heightspd = 2.0f;
            if (_Jump == 0)
            {
                _rb.velocity = new Vector2(0.0f, 4.0f * heightspd);
                Debug.Log("Jump!");
                isGrounded = false;
                _Jump++;
            }
            else
            if (_Jump == 1)
            {

                _rb.velocity = new Vector2(0.0f, 5.0f * heightspd);
                _Anim.SetTrigger("D_Jump");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Works");
            Application.LoadLevel(0);
        }
    }
    IEnumerator attack()
    {
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = false;
        _Anim.SetTrigger("isAttacking");    
        yield return new WaitForSeconds(1.0f);
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
