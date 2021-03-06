using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mesaCocina2 : MonoBehaviour{

    private bool onTable;
    private bool statusdoorA;
    private bool statusdoorB;

    public Text texTable;

    private string buttons;

    public Animator animDoorA;
    public Animator animDoorB;

    public AudioSource audoSource;

    public AudioClip openDoor;
    public AudioClip closeDoor;

    // Start is called before the first frame update
    void Start(){
        statusdoorA = false;
        statusdoorB = false;

        texTable.enabled = false;
    }

    // Update is called once per frame
    void Update(){
        if (onTable){
            makeText();

            if (statusdoorA){
                if (Input.GetKeyDown(KeyCode.Y)){
                    statusdoorA = false;
                    animDoorA.SetBool("action", statusdoorA);
                    playSound(closeDoor);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.Y)){
                    statusdoorA = true;
                    animDoorA.SetBool("action", statusdoorA);
                    playSound(openDoor);
                }
            }

            if (statusdoorB){
                if (Input.GetKeyDown(KeyCode.U)){
                    statusdoorB = false;
                    animDoorB.SetBool("action", statusdoorB);
                    playSound(closeDoor);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.U)){
                    statusdoorA = true;
                    animDoorB.SetBool("action", statusdoorB);
                    playSound(openDoor);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onTable = true;
            texTable.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onTable = false;
            texTable.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (statusdoorA){
            buttons = "Pulsa la tecla Y para cerrar la puerta izquierda\n";
        }
        else{
            buttons = "Pulsa la tecla Y para abrir la puerta izquierda\n";
        }

        if (statusdoorB){
            buttons += "Pulsa la tecla U para cerrar la puerta derecha\n";
        }
        else{
            buttons += "Pulsa la tecla U para abrir la puerta derecha\n";
        }

        texTable.text = buttons;
    }
}
