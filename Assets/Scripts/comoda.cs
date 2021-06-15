using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comoda : MonoBehaviour {

    private bool onSite;

    private bool cage1;
    private bool cage2;
    private bool cage3;
    private bool cage4;

    public Text textComoda;

    private string buttons;

    public Animator animCage1;
    public Animator animCage2;
    public Animator animCage3;
    public Animator animCage4;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    // Start is called before the first frame update
    void Start(){
        cage1 = false;
        cage2 = false;
        cage3 = false;
        cage4 = false;

        textComoda.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update(){
        if (onSite){
            makeText();

            if (cage1){
                if (Input.GetKeyDown(KeyCode.M)){
                    cage1 = false;
                    animCage1.SetBool("action", cage1);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.M)){
                    cage1 = true;
                    animCage1.SetBool("action", cage1);
                    playSound(open);
                }
            }

            if (cage2){
                if (Input.GetKeyDown(KeyCode.N)){
                    cage2 = false;
                    animCage2.SetBool("action", cage2);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.N)){
                    cage2 = true;
                    animCage2.SetBool("action", cage2);
                    playSound(open);
                }
            }

            if (cage3){
                if (Input.GetKeyDown(KeyCode.B)){
                    cage3 = false;
                    animCage3.SetBool("action", cage3);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.B)){
                    cage3 = true;
                    animCage3.SetBool("action", cage3);
                    playSound(open);
                }
            }

            if (cage4){
                if (Input.GetKeyDown(KeyCode.V)){
                    cage4 = false;
                    animCage4.SetBool("action", cage4);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.V)){
                    cage4 = true;
                    animCage4.SetBool("action", cage4);
                    playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onSite = true;
            textComoda.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onSite = false;
            textComoda.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (cage1){
            buttons = "Pulsa la tecla M para cerrar el primer cajon \n";
        }
        else{
            buttons = "Pulsa la tecla M para abrir el primer cajon \n";
        }

        if (cage2){
            buttons += "Pulsa la tecla N para cerrar el segundo cajon \n";
        }
        else{
            buttons += "Pulsa la tecla N para abrir el segundo cajon \n";
        }

        if (cage3){
            buttons += "Pulsa la tecla B para cerrar el tercer cajon \n";
        }
        else{
            buttons += "Pulsa la tecla B para abrir el tercer cajon \n";
        }

        if (cage4){
            buttons += "Pulsa la tecla V para cerrar el cuarto cajon \n";
        }
        else{
            buttons += "Pulsa la tecla V para abrir el cuerto cajon \n";
        }
        textComoda.text = buttons;
    }
}


