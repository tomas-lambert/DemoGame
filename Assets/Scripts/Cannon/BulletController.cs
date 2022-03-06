using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // Variables ------------------------------------------------------------------>

    [SerializeField] private float startForce = 100f;
    [SerializeField] private float torqueForce = 100f;

    private Rigidbody rbBullet;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = GetComponent<Rigidbody>();
        rbBullet.AddRelativeForce(Vector3.forward * startForce * 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
