using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    private Transform _laser;
    private float _spd = 6.0f;
    private float _despawner = 5.0f;
	void Start ()
    {
        _laser = GetComponent<Transform>();
	}

	void Update ()
    {
        _despawner -= Time.deltaTime;
        _laser.position += Vector3.left * Time.deltaTime * _spd;
        if(_despawner == 0)
        {
            Destroy(this);
        }
    }
}
