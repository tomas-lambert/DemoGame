using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    //Variables

    [SerializeField] private GameObject bulletPrephab;

    [SerializeField] private float startTimeShooting;
    [SerializeField] private float bulletSpawnRate;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("bulletSpawner", startTimeShooting, bulletSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void bulletSpawner()
    { 
        bulletPrephab.transform.rotation = transform.rotation;
        Instantiate(bulletPrephab, transform.position, bulletPrephab.transform.rotation);
    }
}
