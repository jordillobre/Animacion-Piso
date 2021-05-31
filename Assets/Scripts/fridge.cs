using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridge : MonoBehaviour{

    private bool onFridge;

    public Animator upDoor;
    public Animator downDoor;
    public Animator cageFridge;
    public Animator cageUp;
    public Animator cageInt;
    public Animator cageDown;

    public bool upDoorIs;
    public bool downDoorIs;
    public bool fridgeCage;
    public bool upCage;
    public bool middleCage;
    public bool infCage;


    // Start is called before the first frame update
    void Start(){
        upDoorIs = false;
        downDoorIs = false;
        fridgeCage = false;
        upCage = false;
        middleCage = false;
        infCage = false;
    }

    // Update is called once per frame
    void Update(){
        if (onFridge){
            if (upDoorIs){
                if (Input.GetKeyDown(KeyCode.Space)){
                    upDoorIs = false;
                    upDoor.SetBool("action", upDoorIs);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.Space)){
                    upDoorIs = true;
                    upDoor.SetBool("action", upDoorIs);
                }
            }

        }

    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onFridge = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onFridge = false;
        }
    }

    void OnGUI(){

        if (onFridge){
            if (upDoorIs){
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to close the door");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to open the door");
            }

            if (downDoorIs){
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to close the door");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to open the door");
            }
        }
    }
}
