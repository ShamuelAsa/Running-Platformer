using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Platform_Script _platformScript;

    public Transform _spawnLoc;
    
    public List<GameObject> _Spawners;
    public bool movedBack = false;
    public bool isGrounded = true;
    public int _maxJump = 2;
    public int _Jump = 0;
    private Rigidbody2D _rb;
    public float timeLeft = 3.0f;
	void Start ()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();	
	}

	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            int index = Random.Range(0, 2);
            Instantiate(_Spawners[index], new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
            timeLeft = 8.5f;
        }
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
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "G-Plat")
        {
            _Jump = 0;
        }
    }

    /*void OnCollisionExit2D(Collision2D col)
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
    }*/
}
