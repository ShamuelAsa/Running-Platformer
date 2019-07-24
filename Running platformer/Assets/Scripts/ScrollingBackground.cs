using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float speed;
    public Renderer renderer;


	void Start () {
		
	}
	

	void Update () {

        renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);

	}
}
