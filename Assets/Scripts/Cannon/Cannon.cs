using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    //Variables ------------------------------------------------------------------------>
     [SerializeField] private GameObject bulletPrephab;
     [SerializeField] private GameObject seePoint;

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
        CannonRotation();
    }

    //Methods ---------------------------------------------------------------------------->

    //Bullet Spawner
    private void bulletSpawner()
    { 
        bulletPrephab.transform.rotation = seePoint.transform.rotation;
        Instantiate(bulletPrephab, seePoint.transform.position, bulletPrephab.transform.rotation);
    }

    public virtual void CannonRotation(){

    }


}
