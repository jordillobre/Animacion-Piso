using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comoda : MonoBehaviour {

    private bool onSite;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onDoor = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
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
