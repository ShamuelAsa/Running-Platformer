using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : MonoBehaviour
{
    private Animator _Anim;
    public int _hpDrone = 1;
    public List<GameObject> _laser;
    public float randomLaunch = 3.0f;
    void Start ()
    {
        _Anim = GetComponent<Animator>();	
	}
	
	void Update ()
    {
        randomLaunch -= Time.deltaTime;
		if(_hpDrone <= 0)
        {
            StartCoroutine(Dead());
        }
        if(randomLaunch <= 0)
        {
            StartCoroutine(ShootLaser());
            randomLaunch = Random.Range(1.0f, 3.0f);
        }
	}

    IEnumerator Dead()
    {
        _Anim.SetTrigger("isDead");
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    IEnumerator ShootLaser()
    {
        _Anim.SetTrigger("Launching");
        int Index = 0;
        yield return new WaitForSeconds(0.5f);
        Instantiate(_laser[Index], gameObject.transform.position, gameObject.transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.gameObject.tag == "Attack")
        {
            _hpDrone--;
        }
    }
}
