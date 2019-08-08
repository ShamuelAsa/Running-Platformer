using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDrone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject _drones = col.gameObject;
        if(col.gameObject.tag == "Drone")
        {
            Debug.Log("Hit the Drone");
            _drones.GetComponent<Drones>()._hpDrone--;
        }
    }
}
