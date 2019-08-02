using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float despawnertimer = 15.0f;

	void Update ()
    {
        despawnertimer -= Time.deltaTime;
        if (despawnertimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
