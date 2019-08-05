using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : MonoBehaviour
{
    private Animator _Anim;
    public int _hpDrone = 1;
    public List<GameObject> _laser;
    public float randomLaunch = 3.0f;
    public GameObject _bolt;
    public BoltsManager bolts_S;
    void Start()
    {
        _Anim = GetComponent<Animator>();
        bolts_S = GameObject.Find("Bolts").GetComponent<BoltsManager>();
    }

    void Update()
    {
        randomLaunch -= Time.deltaTime;
        if (_hpDrone <= 0)
        {
            StartCoroutine(Dead());
        }

        if (randomLaunch <= 0)
        {
            StartCoroutine(ShootLaser());
            randomLaunch = Random.Range(3.0f, 5.0f);
        }
    }

    IEnumerator Dead()
    {
        int randBolts = Random.Range(1, 5);
        _Anim.SetTrigger("isDead");
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        bolts_S._currencyBolts += randBolts;
        for(int i = 0; i < randBolts; i++)
        {
            Instantiate(_bolt, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    IEnumerator ShootLaser()
    {
        _Anim.SetTrigger("Launching");
        int Index = 0;
        yield return new WaitForSeconds(0.5f);
        Instantiate(_laser[Index], gameObject.transform.position, gameObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Player")
        {
            _hpDrone--;
        }
    }
}
