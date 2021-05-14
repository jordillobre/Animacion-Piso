using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wateController : MonoBehaviour{
    public bool onWash;

    private bool theHotWaterIs;
    private bool theColdWaterIs;

    public ParticleSystem hotWater;
    public ParticleSystem coldWater;

    public AudioClip open;
    public AudioClip close;

    public AudioSource audoSource;

    // Start is called before the first frame update
    public void Start(){
        theHotWaterIs = false;
        theColdWaterIs = false;
        hotWater.Stop();
        coldWater.Stop();
    }

    public void Update(){
        if (onWash){
            if (theHotWaterIs){
                if (Input.GetKeyDown(KeyCode.H)){
                    theHotWaterIs = false;
                    hotWater.Stop();
                    Debug.Log(theHotWaterIs);
                    audoSource.loop = false;
                    playSound(close);
                }
            }
            else{
                if (Input.GetKeyDown(KeyCode.H)){
                    theHotWaterIs = true;
                    Debug.Log(theHotWaterIs);
                    audoSource.loop = true;
                    hotWater.Play();
                    playSound(open);
                }
            }

            if (theColdWaterIs){
                if (Input.GetKeyDown(KeyCode.G)){
                    theColdWaterIs = false;
                    coldWater.Stop();
                    audoSource.loop = false;
                    playSound(close);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.G)){
                    theColdWaterIs = true;
                    audoSource.loop = true;
                    coldWater.Play();
                    playSound(open);
                }
            }

        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            onWash = true;
        }

    }

    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            onWash = false;
        }
    }

    void OnGUI(){

        if (onWash){
            if (theHotWaterIs){
                GUI.Box(new Rect(0, 0, 200, 20), "Press G to close the hot water");
            }

            else{
                GUI.Box(new Rect(0, 0, 200, 20), "Press G to open the hot water");
            }

            if (theColdWaterIs){
                GUI.Box(new Rect(0, 20, 200, 20), "Press H to close the cold water");
            }

            else
            {
                GUI.Box(new Rect(0, 20, 200, 20), "Press H to open the cold water");
            }
        }
    }

    void playSound(AudioClip clip){
        audoSource.clip = clip;
        audoSource.Play();
    }
}
