using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour{

    public bool onSwitch;
    public bool lightStatus;
    public GameObject theLight;

    void Start(){
        theLight.SetActive(lightStatus);
    }


    void OnTriggerEnter(Collider other){
        onSwitch = true;
    }
 
    void OnTriggerExit(Collider other){
        onSwitch = false;
    }
 
    void Update(){

        if(theLight.active == true){
            lightStatus = true;
        }

        else{
            lightStatus = false;
        }
 
        if (onSwitch){
            if (lightStatus)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                }
            }
        }
    }
 
    void OnGUI(){

        if (onSwitch) {
            if (lightStatus){
                GUI.Box(new Rect(0, 0, 200, 20), "Press E to close the light");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press E to open the light");
            }
        }
    }
}
