using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    private Transform Stage_obj;

	void Start ()
    {
        Stage_obj = gameObject.GetComponent<Transform>();
        StartCoroutine(movement());
	}


    IEnumerator movement()
    {
        Stage_obj.position -= new Vector3(1 * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Finished moving");
    }
}
