using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    private SpawnPlatforms _plat;
    private SpawnDrones _drone;
    public GameObject _boss, platform;
	void Start ()
    {

        _plat = gameObject.GetComponent<SpawnPlatforms>();
        _drone = gameObject.GetComponent<SpawnDrones>();
        
    }
	
    public void Boss()
    {
        Debug.Log("Boss stage");
        //Executing boss stage.
        _plat.gameObject.GetComponent<SpawnPlatforms>().enabled = false;
        _drone.gameObject.GetComponent<SpawnDrones>().enabled = false;
        //Instantiate()

        //Instantiate floors
        Instantiate(platform, new Vector3(15.0f, 0.0f, 0.0f), Quaternion.identity);

        //Instantiate the boss!!!@thodfshijonmklsdhiotwhjs
    }
}
