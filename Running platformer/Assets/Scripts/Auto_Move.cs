using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour
{
    public float speed;
    public float platSpd = 2.0f;

    void Update ()
    {
        GameObject[] _health = GameObject.FindGameObjectsWithTag("Pickup");
        GameObject[] _drones = GameObject.FindGameObjectsWithTag("Drone");
        GameObject[] _platforms = GameObject.FindGameObjectsWithTag("Platform");
        for (int i = 0; i < _platforms.Length; i++)
        {
            _platforms[i].transform.position += Vector3.left * Time.deltaTime * platSpd;
        }

        for (int i = 0; i < _drones.Length; i++)
        {
            speed = Random.Range(1.0f, 5.0f);
            _drones[i].transform.position += Vector3.left * Time.deltaTime * speed;
        }

        for(int i = 0; i < _health.Length; i++)
        {
            _health[i].transform.position += Vector3.left * Time.deltaTime * 3.0f;
        }
	}
}
