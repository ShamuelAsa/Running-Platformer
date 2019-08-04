using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrones : MonoBehaviour
{
    //Creates a list of drones (Can be used for other different types of drones later on).
    public List<GameObject> _Drones;
    //Timer with a randomized between 3.0f to 5.0f.
    public float timeLeft;
    public float selfDestruct;
	void Start ()
    {
        //spawns a drone when the game starts.
        timeLeft = 0.0f;
	}

    void Update()
    {
        //timeLeft is a timer that goes down by deltaTime (every second).
        timeLeft -= Time.deltaTime;
        selfDestruct -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            int index = 0;
            float rand = Random.Range(-3.0f, 3.0f);
            //Clones the Drone into the game that has been located to the spawn point.
            Instantiate(_Drones[index], new Vector3(15.0f, rand, -1.0f), Quaternion.identity);
            timeLeft = Random.Range(1.0f, 3.0f);
        }
    }
}
