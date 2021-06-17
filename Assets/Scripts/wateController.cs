using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wateController : MonoBehaviour{
    private bool onWash;
    private bool doorAStatus;
    private bool doorBStatus;
    private bool theHotWaterIs;
    private bool theColdWaterIs;

    public Text texTable;

    private string buttons;

    public ParticleSystem hotWater;
    public ParticleSystem coldWater;

    public AudioClip openWaterr;
    public AudioClip closeWater;
    public AudioClip Water;
    public AudioClip openDoor;
    public AudioClip closeDoor;

    public AudioSource audoSource;

    public Animator manillaCaliente;
    public Animator manillaFria;
    public Animator doorA;
    public Animator doorB;

    // Start is called before the first frame update
    public void Start(){
        theHotWaterIs = false;
        theColdWaterIs = false;
        doorAStatus = false;
        doorBStatus = false;
        hotWater.Stop();
        coldWater.Stop();

        texTable.enabled = false;
        buttons = "";
    }

    public void Update(){
        if (onWash){
            makeText();

            if (theHotWaterIs){
                if (Input.GetKeyDown(KeyCode.H)){
                    theHotWaterIs = false;
                    hotWater.Stop();
                    manillaCaliente.SetBool("action", theHotWaterIs); 
                    audoSource.loop = false;
                    //playSound(close);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.H)){
                    theHotWaterIs = true;
                    manillaCaliente.SetBool("action", theHotWaterIs);
                    audoSource.loop = true;
                    hotWater.Play();
                    //playSound(open);
                }
            }

            if (theColdWaterIs){
                if (Input.GetKeyDown(KeyCode.G)){
                    theColdWaterIs = false;
                    coldWater.Stop();
                    audoSource.loop = false;
                    manillaFria.SetBool("action", coldWater);
                    //playSound(close);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.G)){
                    theColdWaterIs = true;
                    audoSource.loop = true;
                    manillaFria.SetBool("action", coldWater);
                    coldWater.Play();
                    //playSound(open);
                }
            }

            if (doorAStatus){
                if (Input.GetKeyDown(KeyCode.J)){
                    doorAStatus = false;
                    doorA.SetBool("action", doorAStatus);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.J)){
                    doorAStatus = true;
                    doorA.SetBool("action", doorAStatus);
                    //playSound(open);
                }
            }

            if (doorBStatus){
                if (Input.GetKeyDown(KeyCode.K)){
                    doorBStatus = false;
                    doorB.SetBool("action", doorBStatus);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.K)){
                    doorBStatus = true;
                    doorB.SetBool("action", doorBStatus);
                    //playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onWash = true;
            texTable.enabled = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onWash = false;
            texTable.enabled = false;
        }
    }

    private void makeText(){
        if (theHotWaterIs){
            buttons = "Pulsa la tecla H para cerrar el agua caliente \n";
        }
        else{
            buttons = "Pulsa la tecla H para abrir el agua caliente \n";
        }

        if (theColdWaterIs){
            buttons += "Pulsa la tecla G para cerrar el agua fria \n";
        }
        else{
            buttons += "Pulsa la tecla G para abrir el agua fria \n";
        }

        if (doorAStatus){
            buttons += "Pulsa la tecla J para cerrar la puerta izquierda \n";
        }
        else{
            buttons += "Pulsa la tecla J para abrir la puerta izquierda \n";
        }

        if (doorBStatus) { 
            buttons += "Pulsa la tecla K para cerrar la puerta derecha \n";
        }
        else{
            buttons += "Pulsa la tecla K para abrir la puerta derechan \n";
        }
        texTable.text = buttons;
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }
}
