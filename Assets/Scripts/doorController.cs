using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class doorController : MonoBehaviour{

    public Animator animacion;

    public bool onDoor;

    private bool theDoorIs;
    public String siteDoor;

    public Text textDoor;

    private string buttons;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();
        theDoorIs = false;
        textDoor.enabled = false;
        buttons = "";
    }

    public void Update(){
        if (onDoor){
            makeText();
            if (theDoorIs){
                if (Input.GetKeyDown(KeyCode.Space)){
                    theDoorIs = false;
                    animacion.SetBool("action", theDoorIs);
                    playSound(close);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    theDoorIs = true;
                    animacion.SetBool("action", theDoorIs);
                    playSound(open);
                }
            }
            
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onDoor = true;
            textDoor.enabled = true;
        }
        
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onDoor = false;
            textDoor.enabled = false;
        }
    }

    void playSound(AudioClip clip)
    {
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (theDoorIs){
            buttons = "Pulsa la barra espaciadora para abrir la puerta de la " + siteDoor + "\n";
        }
        else{
            buttons = "Pulsa la barra espaciadora para cerrar la puerta de la " + siteDoor + "\n";
        }
        textDoor.text = buttons;
    }
}

