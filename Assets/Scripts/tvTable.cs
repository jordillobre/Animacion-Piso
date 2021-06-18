using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tvTable : MonoBehaviour {

    private bool onTable;

    private bool cageLesft;
    private bool cageRight;

    public Text textTable;

    private string buttons;

    public Animator animCageLeft;
    public Animator animCageRight;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;


    // Start is called before the first frame update
    void Start(){
        cageLesft = false;
        cageRight = false;

        textTable.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update(){
        if (onTable){
            makeText();

            if (cageLesft){
                if (Input.GetKeyDown(KeyCode.M)){
                    cageLesft = false;
                    animCageLeft.SetBool("action", cageLesft);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.M)){
                    cageLesft = true;
                    animCageLeft.SetBool("action", cageLesft);
                    playSound(open);
                }
            }

            if (cageRight){
                if (Input.GetKeyDown(KeyCode.N)){
                    cageRight = false;
                    animCageRight.SetBool("action", cageRight);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.N)){
                    cageRight = true;
                    animCageRight.SetBool("action", cageRight);
                    playSound(open);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onTable = true;
            textTable.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onTable = false;
            textTable.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText()
    {
        if (cageLesft){
            buttons = "Pulsa la tecla M para cerrar el cajon izquierdo \n";
        }
        else{
            buttons = "Pulsa la tecla M para abrir el cajon izquierdo \n";
        }

        if (cageRight){
            buttons += "Pulsa la tecla N para cerrar el cajon izquierdo \n";
        }
        else{
            buttons += "Pulsa la tecla N para abrir el cajon derecho \n";
        }

        
        textTable.text = buttons;
    }
}
