using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFocus : Cannon
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speedToLook;
    public override void CannonRotation()
    {
        Vector3 direction = Player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLook * Time.deltaTime);
    }
}
