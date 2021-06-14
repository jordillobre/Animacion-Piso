using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mesaCocina2 : MonoBehaviour{

    private bool onTable;
    public bool statusdoorA;
    public bool statusdoorB;

    public Text texTable;

    private string buttons;

    public Animator animDoorA;
    public Animator animDoorB;

    // Start is called before the first frame update
    void Start(){
        statusdoorA = false;
        statusdoorB = false; 

    }

    // Update is called once per frame
    void Update(){
        if (onTable){
            makeText();

            if (statusdoorA){
                if (Input.GetKeyDown(KeyCode.R)){
                    statusdoorA = false;
                    animDoorA.SetBool("action", statusdoorA);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.R)){
                    statusdoorA = true;
                    animDoorA.SetBool("action", statusdoorA);
                }
            }

            if (statusdoorB){
                if (Input.GetKeyDown(KeyCode.T)){
                    statusdoorB = false;
                    animDoorB.SetBool("action", statusdoorB);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.T)){
                    statusdoorA = true;
                    animDoorB.SetBool("action", statusdoorB);
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

    private void makeText()
    {
        if (statusdoorA){
            buttons = "Pulsa la tecla R para cerrar la puerta izquierda\n";
        }
        else{
            buttons = "Pulsa la tecla R para abrir la puerta izquierda\n";
        }

        if (statusdoorB)
        {
            buttons += "Pulsa la tecla T para cerrar la puerta derecha\n";
        }
        else
        {
            buttons += "Pulsa la tecla T para abrir la puerta derecha\n";
        }

        texTable.text = buttons;
    }
}
