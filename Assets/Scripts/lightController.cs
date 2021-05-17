using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class lightController : MonoBehaviour{

    public bool onSwitch;
    public string site;
    private bool lightStatus;
    public GameObject theLight;

    public AudioClip light;

    public AudioSource audioSource;

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
                    playSound();
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerPrefs.SetInt(site, 1);
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                    playSound();
                }
            }
        }
    }
 
    void OnGUI(){

        if (onSwitch) {
            if (lightStatus){
                GUI.Box(new Rect(0, 0, 200, 20), "Pulsa la tecla E para apagar la luz");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Pulsa la tecla E para encender la luz");
            }
        }
    }

    void playSound(){
        audioSource.clip = light;
        audioSource.Play();

    }
}
