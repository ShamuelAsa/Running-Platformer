using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public Vector3 nextPos;
    private Transform _player;
    private Transform _laser;
    private float _spd = 6.0f;
    private float _despawner = 5.0f;
    public bool aimbot = false;
	void Start ()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _laser = GetComponent<Transform>();
	}

	void Update ()
    {
        _despawner -= Time.deltaTime;
        if (aimbot == false)
        {
            _laser.position += Vector3.left * Time.deltaTime * _spd;
        }
        else
        {
            Vector3 nextPos = Vector3.MoveTowards(transform.position, _player.position, _spd * Time.deltaTime);

            _laser.transform.rotation = LookAt2D(nextPos - _player.transform.position);
            transform.position = nextPos;
        }

        if (_despawner == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Attack" || col.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }

    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
