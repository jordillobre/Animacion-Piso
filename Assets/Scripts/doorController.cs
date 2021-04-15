using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour{

    private Animator animacion;

    public bool theDoorIs;

    // Start is called before the first frame update
    void Start()
    {
        animacion = this.GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                theDoorIs = !theDoorIs;
                Debug.Log("Puerta Abierta");
            }
        }
        
    }
}
