using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Variables ------------------------------------------------------------------>

    [SerializeField] protected float startForce = 10f;
    
    private float timeOfBullet = 2.5f;

    protected Rigidbody rbBullet;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = GetComponent<Rigidbody>();
        BulletForce();
    }

    // Update is called once per frame
    void Update()
    {
        bulletDestroy();
    }

    private void bulletDestroy()
    {
       timeOfBullet -= Time.deltaTime;
       if( timeOfBullet <= 0){
           Destroy(gameObject);
       }
        
    }

    public virtual void BulletForce(){
        rbBullet.AddRelativeForce(Vector3.forward * startForce * 100f);
    }
}
