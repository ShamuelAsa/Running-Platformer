using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    public UIManager _ui;
    private SpawnPlatforms _plat;
    private SpawnDrones _drone;
    public GameObject _boss;
	void Start ()
    {

        _plat = gameObject.GetComponent<SpawnPlatforms>();
        
        _drone = gameObject.GetComponent<SpawnDrones>();

        _ui._preparationStage = true;
    }
	
	void Update ()
    {
        if(_ui._currentDistance == 1000)
        {
            Boss();
        }
        else
        {
            Boss();
        }
	}

    public void Boss()
    {

        //Executing boss stage.
        _plat.gameObject.GetComponent<SpawnPlatforms>().enabled = false;
        _drone.gameObject.GetComponent<SpawnDrones>().enabled = false;
        //Instantiate()
    }
}
