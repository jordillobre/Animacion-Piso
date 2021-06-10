using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mesaCocina3 : MonoBehaviour{

    public Animator door;
    public bool doorStatus;
    public bool onTable;
    public Text texTable;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
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
}
