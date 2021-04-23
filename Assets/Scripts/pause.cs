using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour{

    bool active;
    Canvas canvas;

    // Start is called before the first frame update
    void Start(){

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            active = !active;
            canvas.enabled = active;
        }
    }

    public void exit(){
        Application.Quit();
    }
}
