using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private Transform Stage_obj;

	void Start ()
    {
        Stage_obj = gameObject.GetComponent<Transform>();	
	}

	void Update ()
    {
		while(Stage_obj.position.x > Stage_obj.position.x - 20)
        {
            Stage_obj.position -= new Vector3(3 * Time.deltaTime, 0, 0);
        }
	}
}
