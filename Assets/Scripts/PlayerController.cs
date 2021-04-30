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

    public CharacterController player;
    public float playerSpeed;

    private Vector3 camForward;
    private Vector3 camRight;

    public Camera mainCamera;

    private bool stand;
    private bool sit;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

        stand = true;
        sit = false;

        anim.SetBool("sit", false);
        anim.SetBool("stand", false);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");     

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        if (horizontalMove == 0 || verticalMove == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        /*anim.SetFloat("isWalking", horizontalMove);
        anim.SetFloat("velY", verticalMove);*/

        player.Move(movePlayer * playerSpeed * Time.deltaTime);
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
            if (stand){
                
                if (Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log("me siento");
                    anim.SetBool("sit", true);
                    sit = true;
                    stand = false;
                }
            }
            if (sit){
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("stand", true);
                    anim.SetBool("sit", false);
                    anim.SetBool("stand", false);
                    sit = false;
                    stand = true;
                }

            }
        }
    }
}