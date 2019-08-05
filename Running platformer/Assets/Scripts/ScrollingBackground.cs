using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);

    public Vector2 direction = new Vector2(-1, 0);

    public bool isLooping = false;
    public GameObject loopback;
    private List<SpriteRenderer> backgroundPart;
    public float timer = 3.0f;
    private void Start()
    {
        if(isLooping)
        {
            backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.transform.GetChild(i);

                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                if(r != null)
                {
                    backgroundPart.Add(r);
                }
            }

            backgroundPart = backgroundPart.OrderBy(t => t.transform.position.x).ToList();
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if(isLooping)
        {
            SpriteRenderer firstChild = backgroundPart.FirstOrDefault();
            if(firstChild != null)
            {
                if (firstChild.transform.position.x < loopback.transform.position.x/*Camera.main.transform.position.x*/)
                {
                    //if(firstChild.IsVisibleFrom(Camera.main) == false)
                    //{
                        SpriteRenderer lastChild = backgroundPart.LastOrDefault();

                        firstChild.transform.position = new Vector3(150, firstChild.transform.position.y, firstChild.transform.position.z);

                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    //}
                }
            }
        }
    }
}
