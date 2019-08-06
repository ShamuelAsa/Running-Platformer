using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform _projectile;
    private float spd = 10.0f;
    private float _despawner = 5.0f;
	void Start ()
    {
        _projectile = GetComponent<Transform>();
	}
	
	void Update ()
    {
        _despawner -= Time.deltaTime;
        _projectile.position += Vector3.right * Time.deltaTime * spd;
        if(_despawner == 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "onHit")
        {
            Destroy(gameObject);
        }
    }
}
