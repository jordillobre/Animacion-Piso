using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escritorio : MonoBehaviour{

    private bool onDesktop;
    private bool cage1;
    private bool cage2;
    private bool cage3;
    private bool cage4;

    public Text texDesktop;

    private string buttons;

    public AudioSource audoSource;

    public Animator animCage1;
    public Animator animCage2;
    public Animator animCage3;
    public Animator animCage4;

    public AudioClip open;
    public AudioClip close;

    // Start is called before the first frame update
    void Start(){
        cage1 = false;
        cage2 = false;
        cage3 = false;
        cage4 = false;

        texDesktop.enabled = false;
        buttons = "";
    }

    // Update is called once per frame
    void Update(){
        if (onDesktop){
            makeText();

            if (cage1){
                if (Input.GetKeyDown(KeyCode.H)){
                    cage1 = false;
                    animCage1.SetBool("action", cage1);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.H)){
                    cage1 = true;
                    animCage1.SetBool("action", cage1);
                    playSound(open);
                }
            }

            if (cage2){
                if (Input.GetKeyDown(KeyCode.J)){
                    cage2 = false;
                    animCage2.SetBool("action", cage2);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.J)){
                    cage2 = true;
                    animCage2.SetBool("action", cage2);
                    playSound(open);
                }
            }

            if (cage3){
                if (Input.GetKeyDown(KeyCode.K)){
                    cage3 = false;
                    animCage3.SetBool("action", cage3);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.K)){
                    cage3 = true;
                    animCage3.SetBool("action", cage3);
                    playSound(open);
                }
            }

            if (cage4){
                if (Input.GetKeyDown(KeyCode.L)){
                    cage4 = false;
                    animCage4.SetBool("action", cage4);
                    playSound(close);
                }
            }

            else{
                if (Input.GetKeyDown(KeyCode.L)) {
                    cage4 = true;
                    animCage4.SetBool("action", cage4);
                    playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onDesktop = true;
            texDesktop.enabled = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onDesktop = false;
            texDesktop.enabled = false;
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }

    private void makeText(){
        if (cage1){
            buttons = "Pulsa la tecla H para cerrar el primer cajon \n";
        }
        else{
            buttons = "Pulsa la tecla H para abrir el primer cajon \n";
        }

        if (cage2){
            buttons += "Pulsa la tecla J para cerrar el segundo cajon \n";
        }
        else{
            buttons += "Pulsa la tecla J para abrir el segundo cajon \n";
        }

        if (cage3){
            buttons += "Pulsa la tecla k para cerrar el tercer cajon \n";
        }
        else{
            buttons += "Pulsa la tecla K para abrir el tercer cajon \n";
        }

        if (cage4){
            buttons += "Pulsa la tecla L para cerrar el cuarto cajon \n";
        }
        else{
            buttons += "Pulsa la tecla L para abrir el cuerto cajon \n";
        }
        texDesktop.text = buttons;
    }
}
