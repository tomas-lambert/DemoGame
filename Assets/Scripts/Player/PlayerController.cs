using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Variables -------------------------------->

    //Player Speed
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerSprintSpeed = 1.5f;
    //Time To Jump
    private float resetJumpTimer = 0f;
    [SerializeField] private float cooldownJump = 2f;
    private bool jumpOn = false;
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
        PlayerGravity();
        RotatePlayer();
        PlayerMoves();
        PlayerJump();
        JumpCooldownVerification();
        AnimationValidation();
    }

      //Methods -------------------------------------------------------------------------------->

    // Player Moves---------------------------->

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

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl)){
            jumpOn = true;
            velocity.y = Mathf.Sqrt(-JumpHeigth * GravityForce);
            
        }else{
            PlayerAnimator.SetBool("canJump", false);
        }
        
    }

    //Player Gravity

    public void PlayerGravity(){
        velocity.y += GravityForce * Time.deltaTime;
     
        ccPlayer.Move( velocity * Time.deltaTime);
    }

    //Player Rotation
    private void RotatePlayer(){
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angulo = Quaternion.Euler(0f,cameraAxis,0f);
        transform.localRotation = angulo;

    }

    //Collitions -------------------------------------------------------------------->

    //With Void
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag("Void"))
        {
            Debug.Log("You Dead");
            transform.position = FindObjectOfType<SavePointsManager>().GetSavePoint(GameManager.instance.lastSavePoint).position;
        } 
    }

    // With Save Point
     private void OnTriggerEnter(Collider other) {
         if (other.gameObject.CompareTag("SavePoint"))
        {
            Debug.Log("Save Progress");
            SavePointsManager managerSavePoint = other.transform.parent.GetComponent<SavePointsManager>();
            managerSavePoint.FindSavePoint(other.name);
        }
    }
     //Animations -------------------------------------------------------------------->

    private void AnimationValidation(){
        
        //Walk
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ){
            PlayerAnimator.SetBool("isWalking", true);
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ){
            PlayerAnimator.SetBool("isWalking", false);
        }

        //Run
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl)){
            PlayerAnimator.SetBool("isRun", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftControl)){
            PlayerAnimator.SetBool("isRun", false);
        }

        //Jump
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl)){
            PlayerAnimator.SetBool("canJump", true);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            PlayerAnimator.SetBool("canJump", false);
        }

    }
}
