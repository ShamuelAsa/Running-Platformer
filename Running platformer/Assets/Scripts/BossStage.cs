using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    private SpawnPlatforms _plat;
    private SpawnDrones _drone;
    private Auto_Move _AutoMove;
    public GameObject _boss, platform;
	void Start ()
    {
        _AutoMove = gameObject.GetComponent<Auto_Move>();
        _plat = gameObject.GetComponent<SpawnPlatforms>();
        _drone = gameObject.GetComponent<SpawnDrones>();
        
    }
	
    public void Boss()
    {
        Debug.Log("Boss stage");
        //Executing boss stage.
        _plat.enabled = false;
        _drone.enabled = false;
        //Instantiate()
        StartCoroutine(movementDisabled());

        //Instantiate floors
        Instantiate(platform, new Vector3(5.0f, 0.0f, 0.0f), Quaternion.identity);

        //Instantiate the boss!!!@thodfshijonmklsdhiotwhjs
    }

    IEnumerator movementDisabled()
    {
        Debug.Log("Preparing to stop movement!");
        yield return new WaitForSeconds(8.5f);
        _AutoMove.enabled = false;
    }
}
