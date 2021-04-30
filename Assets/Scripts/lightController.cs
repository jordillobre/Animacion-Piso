using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour{

    public bool onSwitch;
    public string site;
    private bool lightStatus;
    public GameObject theLight;

    void Start(){
        theLight.SetActive(PlayerPrefs.GetInt(site) == 1);
    }


    void OnTriggerEnter(Collider other){
        if (other.tag== "Player")
        {
            onSwitch = true;
        }
        
    }
 
    void OnTriggerExit(Collider other){
        if (other.tag == "Player")
        {
            onSwitch = false;
        }
    }
 
    void Update(){

        if(PlayerPrefs.GetInt(site) == 1){
            lightStatus = true;
        }

        else{
            lightStatus = false;
        }
 
        if (onSwitch){
            if (lightStatus){
                if (Input.GetKeyDown(KeyCode.E)){
                    PlayerPrefs.SetInt(site, 0);
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetInt(site, 1);
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
