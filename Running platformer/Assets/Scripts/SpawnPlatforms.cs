using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public Transform _spawnLoc;

    public List<GameObject> _Spawners;

    public float timeLeft = 8.5f;
    void Start ()
    {
        timeLeft = 0.0f;
	}
	
	void Update ()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            int index = Random.Range(0, 2);
            Instantiate(_Spawners[index], new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
            timeLeft = 8.5f;
        }
    }
}
