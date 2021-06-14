using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mesaCocina3 : MonoBehaviour{

    public Animator door;

    public bool doorStatus;
    public bool onTable;
    public bool waterStatus;

    private string buttons;

    public Text texTable;

    public ParticleSystem water;

    public AudioSource audoSource;

    public AudioClip openWater;
    public AudioClip closeWater;
    public AudioClip openDoor;
    public AudioClip closeDoor;

    // Start is called before the first frame update
    void Start(){
        water.Stop();
        doorStatus = false;
        waterStatus = false;

        texTable.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update(){
        if (onTable){
            makeText();

            if (doorStatus){
                if (Input.GetKeyDown(KeyCode.G)){
                    doorStatus = false;
                    door.SetBool("action", doorStatus);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.G)){
                    doorStatus = true;
                    door.SetBool("action", doorStatus);
                }
            }

            if (waterStatus){
                if (Input.GetKeyDown(KeyCode.H)){
                    waterStatus = false;
                    water.Stop();
                    audoSource.loop = false;
                    playSound(closeWater);
                }

            }
            else{
                if (Input.GetKeyDown(KeyCode.H)){
                    waterStatus = true;
                    audoSource.loop = true;
                    water.Play();
                    playSound(openWater);
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
        if (waterStatus){
            buttons = "Pulsa la tecla H para cerrar el agua\n";
        }
        else{
            buttons = "Pulsa la tecla H para abrir el agua \n";
        }

        if (doorStatus){
            buttons += "Pulsa la tecla G para cerrar la puerta del armario \n";
        }
        else{
            buttons += "Pulsa la tecla G para abrir la puerta del armario \n";
        }

        texTable.text = buttons;
    }
}
