using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _Anim;
    public int _maxJump = 2;
    public int _Jump = 0;
    public int _health = 3;
    public float walkSpdF = 3.5f;
    public float walkSpdB = 5.0f;
    private Rigidbody2D _rb;
    bool isInvincible = false;
    private Renderer _rend;
    public GameObject _atk;
    public GameObject _projectileAtk;
    public bool _gameOver = false;
    void Start()
    {
        _rend = gameObject.GetComponent<Renderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (_health <= 0)
        {
            _gameOver = true;
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(attack());
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(_projectileAtk, gameObject.transform.position, gameObject.transform.rotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && gameObject.transform.position.x >= -5.0f)
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * walkSpdB;
        }

        if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x <= 5.0f)
        {
            gameObject.transform.position += Vector3.right * Time.deltaTime * walkSpdF;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            float fallspd = 3.0f;
            _rb.velocity = new Vector2(0.0f, -1.0f * fallspd);
        }
        if (!isGrounded() && _Jump == 0)
        {
            _Anim.SetBool("Jumping", true);
        } 
        else if(isGrounded())
        {
            _Anim.SetBool("Jumping", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _Jump <= _maxJump - 1)
        {
            float heightspd = 2.0f;
            _Jump++;
            if (isGrounded() || !isGrounded())
            {
                if (_Jump == 0)
                {
                    _rb.velocity = new Vector2(0.0f, 4.0f * heightspd);
                    Debug.Log("Jump!");
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        Debug.Log("Attack & Jump!");
                        StartCoroutine(attack());
                    }
                }
                if(_Jump >= 1 && !isGrounded())
                {
                    Debug.Log("Double Jump!");
                    _rb.velocity = new Vector2(0.0f, 5.0f * heightspd);
                    StartCoroutine(D_Attack());
                    _Jump++;
                    return;
                }
            }
        }
    }

    public bool isGrounded()
    {
        LayerMask mask = LayerMask.GetMask("Floor");
        Vector2 pos = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.5f;

        RaycastHit2D hit = Physics2D.Raycast(pos, direction, distance, mask);
        if (hit.collider != null)
        {
            _Jump = 0;
            return true;
        }
        return false;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Death")
        {
            _gameOver = true;
            Application.LoadLevel(0);
        }

        if (collision.gameObject.tag == "onHit" && isInvincible == false)
        {
            StartCoroutine(onHitBlink());
            Destroy(collision.gameObject);
            _health--;
        }
    }

    private void OnColliderEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Drone" && isInvincible == false)
        {
            StartCoroutine(onHitBlink());
            Debug.Log("Hit!");
            _health--;
        }
    }

    IEnumerator D_Attack()
    {
        _atk.SetActive(true);
        _Anim.SetTrigger("D_Jump");
        yield return new WaitForSeconds(0.3f);
        _atk.SetActive(false);
    }

    IEnumerator attack()
    {
        _atk.SetActive(true);
        _Anim.SetTrigger("Attacking");
        yield return new WaitForSeconds(0.3f);
        _atk.SetActive(false);
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
