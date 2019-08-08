using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drones : MonoBehaviour
{
    private Animator _Anim;
    public int _hpDrone = 1;
    public List<GameObject> _laser;
    private float randomLaunch = 3.0f;
    public GameObject _bolt;
    public BoltsManager bolts_S;
    bool isDead = false;

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
            isDead = true;
            _Anim.SetTrigger("isDead");
            StartCoroutine(Dead());
        }

        if (randomLaunch <= 0 && isDead == false)
        {
            StartCoroutine(ShootLaser());
            randomLaunch = Random.Range(3.0f, 5.0f);
        }
    }

    IEnumerator Dead()
    {
        int randBolts = Random.Range(1, 5);        
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        bolts_S._currencyBolts += randBolts;
        for(int i = 0; i < randBolts; i++)
        {
            Instantiate(_bolt, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), gameObject.transform.rotation);
        }
    }

    IEnumerator ShootLaser()
    {
        var positioning = new Vector3(gameObject.transform.position.x - 4.0f, gameObject.transform.position.y, gameObject.transform.position.z);
        _Anim.SetTrigger("Launching");
        int Index = 0;
        yield return new WaitForSeconds(1.0f);
        Instantiate(_laser[Index], positioning, gameObject.transform.rotation);
    }
}
