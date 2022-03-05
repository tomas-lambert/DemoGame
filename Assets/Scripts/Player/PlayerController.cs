using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variables -------------------------------->

    //Player Speed
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerSprintSpeed = 1.5f;
    //Time To Jump
    private float resetJumpTimer = 0f;
    [SerializeField] private float cooldownJump = 2f;
    private bool jumpOn =false;
    [SerializeField] private float JumpHeigth = 2f;

    //Gravity Force
    [SerializeReference] private float GravityForce = -9.81f;
    private Vector3 velocity;

    //Camera Axis
    private float cameraAxis;

    //Animator
    [SerializeField] private Animator PlayerAnimator;

    //Player Elements
    private CharacterController ccPlayer;

    // Start is called before the first frame update
    void Start()
    {
         ccPlayer = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      //Methods ----------------------------->

    // Player Moves

    public void PlayerMoves()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");

        if (ejeHorizontal !=0 || ejeVertical !=0)
        {
            //transform.Translate(playerSpeed * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical ));
            ccPlayer.Move(playerSpeed * Time.deltaTime * transform.TransformDirection(new Vector3(ejeHorizontal, 0, ejeVertical )));
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl)){
             ccPlayer.Move((playerSpeed * playerSprintSpeed) * Time.deltaTime * transform.TransformDirection(new Vector3(ejeHorizontal, 0, ejeVertical )));
        }
        
    }

    //Player Jump

    public void JumpCooldownVerification(){
        if (jumpOn)
        {
            resetJumpTimer += Time.deltaTime;
        }
        if (resetJumpTimer > cooldownJump)
        {
            jumpOn = false;
            resetJumpTimer = 0f;
        }

        Debug.Log(jumpOn);
        Debug.Log(resetJumpTimer);
    }
    public void PlayerJump(){

        if((Input.GetKeyDown(KeyCode.Space) && ccPlayer.isGrounded && !jumpOn) || (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && ccPlayer.isGrounded && !jumpOn) || (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl) && ccPlayer.isGrounded && !jumpOn) ){
            jumpOn = true;
            velocity.y = Mathf.Sqrt(-JumpHeigth * GravityForce);
            PlayerAnimator.SetBool("isJump", true);
        }else{
            PlayerAnimator.SetBool("isJump", false);
        }
        
    }

    //Player Gravity

    public void PlayerGravity(){
        velocity.y += GravityForce * Time.deltaTime;
     
        ccPlayer.Move( velocity * Time.deltaTime);
    }

    //Player Rotation
    private void RotatePlayer()
    {
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0f,cameraAxis,0f);
        transform.localRotation = angulo;

    }
}
