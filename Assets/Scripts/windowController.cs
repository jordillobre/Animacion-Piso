using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowController : MonoBehaviour{
    public Animator animacion;

    public bool onWindow;

    private bool theRightWindow;
    private bool theLeftWindow;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();
        theRightWindow = false;
        theLeftWindow = false;
    }

    public void Update(){
        if (onWindow){
            if (theRightWindow){
                if (Input.GetKeyDown(KeyCode.R)){
                    theRightWindow = false;
                    animacion.SetBool("rightWindow", theRightWindow);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.R)){
                    theRightWindow = true;
                    animacion.SetBool("rightWindow", theRightWindow);
                    playSound(open);
                }
            }

            if (theLeftWindow){
                if (Input.GetKeyDown(KeyCode.T)){
                    theLeftWindow = false;
                    animacion.SetBool("leftWindow", theLeftWindow);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.T)){
                    theLeftWindow = true;
                    animacion.SetBool("leftWindow", theLeftWindow);
                    playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onWindow = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onWindow = false;
        }
    }

    void OnGUI(){

        if (onWindow){
            if (theRightWindow){
                GUI.Box(new Rect(0, 0, 200, 20), "Press R to close the door");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press R to open the door");
            }

            if (theLeftWindow)
            {
                GUI.Box(new Rect(0, 20, 200, 20), "Press T to close the door");
            }

            else
            {
                GUI.Box(new Rect(0, 20, 200, 20), "Press T to open the door");
            }
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }
}
