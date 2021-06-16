using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class retrete : MonoBehaviour{

    private bool onWC;
    private bool tapa1Status;
    private bool tapa2Status;

    public Text texRetrete;

    private string buttons;

    public Animator tapa1;
    public Animator tapa2;

    public AudioSource audoSource;

    public AudioClip cadena;

    // Start is called before the first frame update
    void Start(){
        tapa1Status = false;
        tapa2Status = false;

        texRetrete.enabled = false;
        buttons = "";

    }

    // Update is called once per frame
    void Update(){
        if (onWC){
            makeText();

            if (tapa2Status){
                if (Input.GetKeyDown(KeyCode.T)){
                    if (!tapa1Status){
                        tapa2Status = false;
                        tapa2.SetBool("action", tapa2Status);
                    }
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.T)){
                    tapa2Status = true;
                    tapa2.SetBool("action", tapa2Status);
                }
            }

            if (tapa1Status){
                if (Input.GetKeyDown(KeyCode.Y)){
                    tapa1Status = false;
                    tapa1.SetBool("action", tapa1Status);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.Y)){
                    if (tapa2Status){
                        tapa1Status = true;
                        tapa1.SetBool("action", tapa1Status);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.U)){
                playSound(cadena);
            }

        }

    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
            onWC = true;
            texRetrete.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onWC = false;
            texRetrete.enabled = false;
        }
    }

    void playSound(AudioClip clip)
    {
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (tapa1Status){
            buttons = "Pulsa la tecla T para cerrar la primera tapa\n";
        }
        else{
            buttons = "Pulsa la tecla T para abrir la primera tapa \n";
        }

        if (tapa2Status){
            buttons += "Pulsa la tecla Y para cerrar la segunda tapa \n";
        }
        else{
            buttons += "Pulsa la tecla G para abrir la segunda tapa \n";
        }

        buttons += "Pulsa la tecla U para tirar de la cdena \n";

        texRetrete.text = buttons;
    }
}
