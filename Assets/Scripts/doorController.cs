using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour{

    public Animator animacion;

    public bool onDoor;

    public bool theDoorIs;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();

    }

    public void Update(){
        if (onDoor){
            if (theDoorIs){
                if (Input.GetKey(KeyCode.Space)){
                    theDoorIs = false;
                    animacion.SetBool("action", theDoorIs);
                }
            }
            else{
                theDoorIs = true;
                animacion.SetBool("action", theDoorIs);
            }
            
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onDoor = true;
        }
        
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            onDoor = false;
        }
    }
    void OnGUI(){

        if (onDoor){
            if (theDoorIs){
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to close the door");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to open the door");
            }
        }
    }
}

