using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour { 
    private float horizontalMove;
    private float verticalMove;

    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Vector3 camForward;
    private Vector3 camRight;

    private Animator anim;

    private bool onSit;
    private bool onBed;
    private bool onDoor;
    private bool onSink;

    public bool stand;
    public bool sit;
    public bool canWalk;
    public bool lie;
    public bool washinHandsCold;
    public bool washinHandsHot;
    public bool sleep;

    public CharacterController player;
    public float playerSpeed;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<CharacterController>();

        canWalk = true;
        stand = true;
        sleep = false;
        sit = false;
        lie = false;
        washinHandsCold = false;
        washinHandsHot = false;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (canWalk){
            move(horizontalMove, verticalMove);
        }
        
        if (onSit){
            if (sit){ //ponerse en pie
                if (Input.GetKeyDown(KeyCode.R)){
                    standUP();
                }
            }

            if (stand){//sentarse
                if (Input.GetKeyDown(KeyCode.T)){
                    sitDonw();
                }
            }
        }

        if (onSink){
            if (washinHandsCold || washinHandsHot){
                if (Input.GetKeyDown(KeyCode.G)){
                    washinHandsCold = !washinHandsCold;
                }
                if (Input.GetKeyDown(KeyCode.G)){
                    washinHandsHot = !washinHandsHot; 
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.G)){
                    washinHandsCold = !washinHandsCold;
                }
                if (Input.GetKeyDown(KeyCode.G)){
                    washinHandsHot = !washinHandsHot;
                }
            }
        }

    }
    void standUP(){
        anim.SetBool("sit", false);
        anim.SetBool("stand", true);
        sit = false;
        stand = true;
        canWalk = true;
        StartCoroutine(waitSit());
    }

    IEnumerator waitStand(){
        yield return new WaitForSeconds(1);
        anim.SetBool("stand", false);
        //canWalk = true;
        //stand = true;
        //sit = false;
    }

    void sitDonw(){
        anim.SetBool("sit", true);
        sit = true;
        stand = false;
        canWalk = false;
        StartCoroutine(waitStand());
    }

    IEnumerator waitSit(){
        yield return new WaitForSeconds(1);
        //anim.SetBool("sit", false);
        //canWalk = false;
        //sit = true;
        //stand = false;
    }

    void move(float h, float v){
        playerInput = new Vector3(h, 0, v);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);

        if (h == 0 && v == 0){
            anim.SetBool("isWalking", false);
        }
        else{
            anim.SetBool("isWalking", true);
        }
    }

    void getUp(){//levantarse de la cama
        anim.SetBool("sleep", true);
        sleep = true;
        canWalk = false;
    }

    void lieDown(){//acostarse en la cama
        anim.SetBool("sleep", false);
        sleep = false;
        canWalk = true;
    }

    /*void openDoor(){

    }

    void closeDoor(){

    }*/

    void handwashing(){//limpiarse las manos
        if (washinHandsHot || washinHandsCold){
            anim.SetBool("washing", true);
            canWalk = false;
        }

        else{
            anim.SetBool("washing", false);
            canWalk = true;
        }
    }

    void camDirection(){
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    private void OnTriggerStay(Collider other){
        if (other.tag == "Asiento"){
            onSit = true;
        }
        if (other.tag == "Cama"){
            onBed = true;
        }
        if (other.tag == "Puerta"){
            onDoor = true;
        }
        if (other.tag == "Lavabo")
        {
            onSink = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Asiento"){
            onSit = false;
        }
        if (other.tag == "Cama") { 
            onBed = false;
        }
        if (other.tag == "Puerta"){
            onDoor = false;
        }
        if (other.tag == "Lavabo"){
            onSink = false;
        }
    }
 
    void OnGUI(){

        if (onSit){
            if (stand){
                GUI.Box(new Rect(0, 0, 200, 20), "Pulsa T para sentarte");
            }

            if (sit){
                GUI.Box(new Rect(0, 0, 200, 20), "Pulsa R para levantarte");
            }
        }
    }
}