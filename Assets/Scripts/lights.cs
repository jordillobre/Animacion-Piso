using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Pasillo", 1);
        PlayerPrefs.SetInt("Cocina", 0);
        PlayerPrefs.SetInt("Ba�o1", 0);
        PlayerPrefs.SetInt("Habitacion1", 0);
        PlayerPrefs.SetInt("Ba�o2", 0);
        PlayerPrefs.SetInt("Habitacion2", 0);
        PlayerPrefs.SetInt("Comedor", 0);
    }

}
