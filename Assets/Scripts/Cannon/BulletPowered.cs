using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowered : BulletController
{
    public override void BulletForce()
    {
        rbBullet.AddRelativeForce(Vector3.forward * startForce * 200f);
    }
}
