using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class lightController : MonoBehaviour{

    public bool onSwitch;
    public string site;
    private bool lightStatus;
    public GameObject theLight;

    public AudioClip lightAudio;

    public string siteLight;
    public Text textLight;

    private string buttons;

    public AudioSource audioSource;

    void Start(){
        theLight.SetActive(PlayerPrefs.GetInt(site) == 1);
        textLight.enabled = false;
    }


    void OnTriggerEnter(Collider other){
        if (other.tag== "Player"){
            onSwitch = true;
            textLight.enabled = true;
        }
        
    }
 
    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onSwitch = false;
            textLight.enabled = false;
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
            makeText();
            if (lightStatus){
                if (Input.GetKeyDown(KeyCode.E)){
                    PlayerPrefs.SetInt(site, 0);
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                    playSound();
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.E)){
                    PlayerPrefs.SetInt(site, 1);
                    lightStatus = !lightStatus;
                    theLight.SetActive(lightStatus);
                    playSound();
                }
            }
        }
    }

    private void makeText(){
        if (lightStatus){
            buttons = "Pulsa la tecla E para apagar la luz " + siteLight;
        }

        else{
            buttons = "Pulsa la tecla E para encender la luz " + siteLight;
        }
        textLight.text = buttons;
    }

    void playSound(){
        audioSource.clip = lightAudio;
        audioSource.Play();
    }
}
