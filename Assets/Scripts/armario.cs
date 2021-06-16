using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armario : MonoBehaviour {

    private bool onSite;
    private bool doorA;
    private bool doorB;
    private bool cage1;
    private bool cage2;

    public Animator animDoorA;
    public Animator animDoorB;
    public Animator animCage1;
    public Animator animCage2;

    public Text textArmario;

    private string buttons;

    public AudioSource audoSource;
    public AudioClip openDoor;
    public AudioClip closeDoor;
    public AudioClip openCage;
    public AudioClip closeCage;

    // Start is called before the first frame update
    void Start(){
        doorA = false;
        doorB = false;
        cage1 = false;
        cage2 = false;

        textArmario.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update() {
        if (onSite){
            makeText();

            if (doorA){
                if ((cage1 == false) && (cage2 == false)){
                    if (Input.GetKeyDown(KeyCode.Q)){
                        doorA = false;
                        animDoorA.SetBool("action", doorA);
                        playSound(closeDoor);
                    }
                }

            }
            else{
                if (Input.GetKeyDown(KeyCode.Q)){
                    doorA = true;
                    animDoorA.SetBool("action", doorA);
                    playSound(openDoor);
                }
            }

            if (doorB){
                if ((cage1 == false) && (cage2 == false)){
                    if (Input.GetKeyDown(KeyCode.E)){
                        doorB = false;
                        animDoorB.SetBool("action", doorB);
                        playSound(closeDoor);
                    }
                }

            }
            else{
                if (Input.GetKeyDown(KeyCode.E)){
                    doorB = true;
                    animDoorB.SetBool("action", doorB);
                    playSound(openDoor);
                }
            }

            if ((doorA == true) && (doorB == true)){
                if (cage1){
                    if (Input.GetKeyDown(KeyCode.R)){
                        cage1 = false;
                        animCage1.SetBool("action", cage1);
                        playSound(closeCage);
                    }

                }
                else{
                    if (Input.GetKeyDown(KeyCode.R)){
                        cage1 = true;
                        animCage1.SetBool("action", cage1);
                        playSound(openCage);
                    }
                }

                if (cage2){
                    if (Input.GetKeyDown(KeyCode.T)){
                        cage2 = false;
                        animCage2.SetBool("action", cage2);
                        playSound(closeCage);
                    }

                }
                else{
                    if (Input.GetKeyDown(KeyCode.T)){
                        cage2 = true;
                        animCage2.SetBool("action", cage2);
                        playSound(openCage);
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onSite = true;
            textArmario.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onSite = false;
            textArmario.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (doorA){
            buttons = "Pulsa la tecla Q para cerrar una de las puertas \n";
        }
        else{
            buttons = "Pulsa la tecla Q para abrir una de las puertas \n";
        }

        if (cage2){
            buttons += "Pulsa la tecla E para cerrar el segundo cajon \n";
        }
        else{
            buttons += "Pulsa la tecla E para abrir el segundo cajon \n";
        }

        if (cage1){
            buttons += "Pulsa la tecla R para cerrar el cajon superior \n";
        }
        else{
            buttons += "Pulsa la tecla R para abrir el cajon superior \n";
        }

        if (cage2){
            buttons += "Pulsa la tecla T para cerrar el cajon inferior \n";
        }
        else{
            buttons += "Pulsa la tecla T para abrir el cajon inferior \n";
        }
        textArmario.text = buttons;
    }
}
