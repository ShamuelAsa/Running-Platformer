using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour
{
    public float speed = 3.0f;
    public float platSpd = 2.0f;

    void Update ()
    {

        GameObject[] _drones = GameObject.FindGameObjectsWithTag("Drone");
        GameObject[] _platforms = GameObject.FindGameObjectsWithTag("Platform");
        for (int i = 0; i < _platforms.Length; i++)
        {
            _platforms[i].transform.position += Vector3.left * Time.deltaTime * platSpd;
        }

        for (int i = 0; i < _drones.Length; i++)
        {
            _drones[i].transform.position += Vector3.left * Time.deltaTime * speed;
        }
	}
}
