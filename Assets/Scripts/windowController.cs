using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowController : MonoBehaviour{
    public Animator animacion;

    public bool onWindow;

    private bool theRightWindow;
    private bool theLeftWindow;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    public Text textWindow;

    private string buttons;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();
        theRightWindow = false;
        theLeftWindow = false;

        textWindow.enabled = false;
    }

    public void Update(){
        if (onWindow){

            makeText();

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
            textWindow.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onWindow = false;
            textWindow.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (theRightWindow){
            buttons = "Pulsa la tecla R para cerrar la ventana izquierda\n";
        }
        else{
            buttons = "Pulsa la tecla R para abrir la ventana izquierda\n";
        }

        if (theLeftWindow){
            buttons += "Pulsa la tecla T para cerrar la ventana derecha\n";
        }
        else{
            buttons += "Pulsa la tecla T para abrir la ventana derecha\n";
        }

        textWindow.text = buttons;
    }
}
