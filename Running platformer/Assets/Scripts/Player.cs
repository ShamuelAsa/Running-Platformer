using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _Anim;
    public bool isGrounded = true;
    public int _maxJump = 2;
    public int _Jump = 0;
    public int _health = 3;
    private Rigidbody2D _rb;
    private GameObject _attackcollider;
    bool isInvincible = false;
    private Renderer _rend;
	void Start ()
    {
        _rend = gameObject.GetComponent<Renderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponent<Animator>();
        _attackcollider = GameObject.Find("AttackCollision");
	}

    void Update()
    {
        if(_health <= 0)
        {
            Application.LoadLevel(0);
        }

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
                StartCoroutine(D_Attack());
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
        if (collision.gameObject.tag == "onHit" && isInvincible == false || collision.gameObject.tag == "Drone" && isInvincible == false)
        {
            StartCoroutine(onHitBlink());
            _health--;
        }
    }

    IEnumerator D_Attack()
    {
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = false;
        _Anim.SetTrigger("D_Jump");
        yield return new WaitForSeconds(1.0f);
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    IEnumerator attack()
    {
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = false;
        _Anim.SetTrigger("isAttacking");    
        yield return new WaitForSeconds(1.0f);
        _attackcollider.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    IEnumerator onHitBlink()
    {
        isInvincible = true;
        _rend.material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        _rend.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _rend.material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        _rend.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        _rend.material.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        _rend.material.color = Color.white;
        yield return new WaitForSeconds(1.0f);
        isInvincible = false;
    }
}
