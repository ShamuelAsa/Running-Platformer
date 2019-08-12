using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpin : MonoBehaviour
{
    private Transform _bolt;
    private float timer;
    void Start()
    {
        timer = 3.0f;
        _bolt = GetComponent<Transform>();
    }
    void Update ()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
            timer = 3.0f;
        }
        _bolt.transform.Rotate(new Vector3(0, 0, 3));
	}
}
