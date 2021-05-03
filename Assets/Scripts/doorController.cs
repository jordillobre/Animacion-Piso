using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class doorController : MonoBehaviour{

    public Animator animacion;

    public bool onDoor;

    private bool theDoorIs;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();
        theDoorIs = false;
    }

    public void Update(){
        if (onDoor){
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

    void playSound(AudioClip clip)
    {
        audoSource.clip = clip;
        audoSource.Play();
    }
}

