using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comoda : MonoBehaviour {

    private bool onSite;

    private bool cage1;
    private bool cage2;
    private bool cage3;
    private bool cage4;

    public Animator animCage1;
    public Animator animCage2;
    public Animator animCage3;
    public Animator animCage4;

    // Start is called before the first frame update
    void Start(){
        cage1 = false;
        cage2 = false;
        cage3 = false;
        cage4 = false;
    }

    // Update is called once per frame
    void Update(){
        if (onSite){
            if (cage1){
                if (Input.GetKeyDown(KeyCode.M)){
                    cage1 = false;
                    animCage1.SetBool("action", cage1);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.M)){
                    cage1 = true;
                    animCage1.SetBool("action", cage1);
                    //playSound(open);
                }
            }

            if (cage2){
                if (Input.GetKeyDown(KeyCode.N)){
                    cage2 = false;
                    animCage2.SetBool("action", cage2);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.N)){
                    cage2 = true;
                    animCage2.SetBool("action", cage2);
                    //playSound(open);
                }
            }

            if (cage3){
                if (Input.GetKeyDown(KeyCode.B)){
                    cage3 = false;
                    animCage3.SetBool("action", cage3);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.B)){
                    cage3 = true;
                    animCage3.SetBool("action", cage3);
                    //playSound(open);
                }
            }

            if (cage4){
                if (Input.GetKeyDown(KeyCode.V)){
                    cage4 = false;
                    animCage4.SetBool("action", cage4);
                    //playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.V)){
                    cage4 = true;
                    animCage4.SetBool("action", cage4);
                    //playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onSite = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onSite = false;
        }
    }

    void OnGUI(){

        if (onSite){
            if (cage1){
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to close the door");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press Space to open the door");
            }
        }
    }
}
