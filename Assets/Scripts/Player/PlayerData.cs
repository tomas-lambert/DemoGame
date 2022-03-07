using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New PlayerData", menuName="Player Data")]
public class PlayerData : ScriptableObject
{
    public float playerSpeed = 10f;
    public float playerSprintSpeed = 1.5f;

    public float cooldownJump = 2f;

    public float JumpHeigth = 2f;

    public float GravityForce = -9.81f;
}
