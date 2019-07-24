using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Platform_Script _platformScript;

    public Transform _spawnLoc;
    public GameObject _Spawner;

    public bool movedBack = false;
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
                movedBack = false;
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
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;
            _Jump = 0;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        float _axis = Random.Range(-3.0f, 3.0f);
        if(col.gameObject.tag == "Platform")
        {
            isGrounded = false;
            if(_platformScript.touched == false)
            {
                Instantiate(_Spawner, new Vector3(14.0f, _axis, 0.0f), Quaternion.identity);
            }
        }
    }
}
