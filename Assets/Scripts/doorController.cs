using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour{

    public Animator animacion;

    public bool onDoor;

    public bool theDoorIs;

    // Start is called before the first frame update
    public void Start(){
        animacion = this.GetComponent<Animator>();
        Debug.Log(theDoorIs);

    }

    public void Update(){
        if (onDoor){
            if (theDoorIs){
                if (Input.GetKey(KeyCode.E)){
                    theDoorIs = false;
                    animacion.SetBool("action", theDoorIs);
                }
            }
            else{
                theDoorIs = true;
                animacion.SetBool("action", theDoorIs);
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        onDoor = true;
    }

    void OnTriggerExit(Collider other)
    {
        onDoor = false;
    }

}
