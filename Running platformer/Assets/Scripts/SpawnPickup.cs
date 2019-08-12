using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup : MonoBehaviour
{
    public List<GameObject> items;

    public float timeLeft;

	void Start ()
    {
        timeLeft = 5.0f;	
	}
	
	void Update ()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            int index = 0;
            float rand = Random.Range(-3.0f, 2.0f);

            Instantiate(items[index], new Vector3(15.0f, rand, -1.0f), Quaternion.identity);
            timeLeft = Random.Range(10.0f, 30.0f);
        }
	}
}
