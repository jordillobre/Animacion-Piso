using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fridge : MonoBehaviour{

    private bool onFridge;

    public Animator upDoor;
    public Animator downDoor;
    public Animator cageFridge;
    public Animator cageUp;
    public Animator cageInt;
    public Animator cageDown;

    public Text textFridge;

    private string buttons;

    public bool upDoorIs;
    public bool downDoorIs;
    public bool fridgeCage;
    public bool upCageIs;
    public bool middleCageIs;
    public bool infCageIs;

    public AudioClip openUpDoor;
    public AudioClip closeUpDoor;
    public AudioClip openDownDoor;
    public AudioClip closeDownDoor;
    public AudioClip openCage;
    public AudioClip closeCage;

    public AudioSource audoSource;


    // Start is called before the first frame update
    void Start(){
        upDoorIs = false;
        downDoorIs = false;
        fridgeCage = false;
        upCageIs = false;
        middleCageIs = false;
        infCageIs = false;

        textFridge.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update(){
        if (onFridge){
            makeText();
            if (upDoorIs){
                if (Input.GetKeyDown(KeyCode.R)){
                    if (fridgeCage == false){
                        upDoorIs = false;
                        upDoor.SetBool("action", upDoorIs);
                        playSound(closeUpDoor);
                    }
                    
                }

                if (fridgeCage){
                    if (Input.GetKeyDown(KeyCode.M)){
                        fridgeCage = false;
                        cageFridge.SetBool("action", fridgeCage);
                        playSound(openCage);
                    }
                }

                else{
                    if (Input.GetKeyDown(KeyCode.M)){
                        fridgeCage = true;
                        cageFridge.SetBool("action", fridgeCage);
                        playSound(openCage);
                    }
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.R)){
                    upDoorIs = true;
                    upDoor.SetBool("action", upDoorIs);
                    playSound(openUpDoor);
                }
            }

            if (downDoorIs){
                if (Input.GetKeyDown(KeyCode.T)){
                    if ((upCageIs == false) && (middleCageIs == false) && (infCageIs == false)){
                        downDoorIs = false;
                        downDoor.SetBool("action", downDoorIs);
                        playSound(closeDownDoor);
                    }
                    
                }

                if (upCageIs){
                    if (Input.GetKeyDown(KeyCode.L)){
                        upCageIs = false;
                        cageUp.SetBool("action", upCageIs);
                        playSound(openCage);
                    }
                }
                else{
                    if (Input.GetKeyDown(KeyCode.L)){
                        upCageIs = true;
                        cageUp.SetBool("action", upCageIs);
                        playSound(openCage);
                    }
                }

                if (middleCageIs){
                    if (Input.GetKeyDown(KeyCode.K)){
                        middleCageIs = false;
                        cageInt.SetBool("action", middleCageIs);
                        playSound(openCage);
                    }
                }
                else{
                    if (Input.GetKeyDown(KeyCode.K)){
                        middleCageIs = true;
                        cageInt.SetBool("action", middleCageIs);
                        playSound(openCage);
                    }
                }

                if (infCageIs){
                    if (Input.GetKeyDown(KeyCode.J)){
                        infCageIs = false;
                        cageDown.SetBool("action", infCageIs);
                        playSound(openCage);
                    }
                }
                else{
                    if (Input.GetKeyDown(KeyCode.J)){
                        infCageIs = true;
                        cageDown.SetBool("action", infCageIs);
                        playSound(openCage);
                    }
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.T)){
                    downDoorIs = true;
                    downDoor.SetBool("action", downDoorIs);
                    playSound(openDownDoor);
                }
            }
        }

    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onFridge = true;
            textFridge.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onFridge = false;
            textFridge.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }
    private void makeText(){
        if (upDoorIs){
            buttons = "Pulsa la tecla R para cerrar la puerta superior\n";
            
            if (fridgeCage){
                buttons += "Pulsa la tecla M para cerrar el cajon de la nevera\n";
            }
            else{
                buttons += "Pulsa la tecla M para abrir el cajon de la nevera\n";
            }
        }
        else{
            buttons = "Pulsa la tecla R para abrir la puerta superior\n";
        }

        if (downDoorIs){
            buttons += "Pulsa la tecla T para cerrar la puerta inferior\n";

            if (upCageIs){
                buttons += "Pulsa la tecla L para cerrar el cajon superior\n";
            }
            else{
                buttons += "Pulsa la tecla L para abrir el cajon superior\n";
            }
        }
        else{
            buttons += "Pulsa la tecla T para abrir la puerta inferior\n";
        }

        textFridge.text = buttons;
    }

}
