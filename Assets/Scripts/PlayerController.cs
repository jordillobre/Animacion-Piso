using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Animator anim;
    private bool onSit;

    public CharacterController player;
    public float playerSpeed;

    private Vector3 camForward;
    private Vector3 camRight;

    public Camera mainCamera;

    private bool stand;
    private bool sit;

    // Start is called before the first frame update
    void Start(){
        player = GetComponent<CharacterController>();

        onSit = false;

        anim = GetComponent<Animator>();

        stand = true;
        sit = false;
    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        move(horizontalMove, verticalMove);

        if (onSit){
            if (sit){
                if (Input.GetKeyDown(KeyCode.Space)){
                    anim.SetBool("stand", true);
                    sit = false;
                    stand = true;
                    playerSpeed = 1f;
                    StartCoroutine(waitSit());
                }
            }
            if (stand){
                if (Input.GetKeyDown(KeyCode.Space)){
                    anim.SetBool("sit", true);
                    sit = true;
                    stand = false;
                    playerSpeed = 0f;
                    StartCoroutine(waitStand());
                }
            }
        }

    }

    IEnumerator waitStand(){
        yield return new WaitForSeconds(1);
        anim.SetBool("stand", false);
    }

    IEnumerator waitSit(){
        yield return new WaitForSeconds(1);
        anim.SetBool("sit", false);
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Asiento"){
            onSit = false;
        }
    }
}