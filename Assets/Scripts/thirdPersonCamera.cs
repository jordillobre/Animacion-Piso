using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    private Transform target;

    public Vector3 offset;
    [Range (0 , 1)] public float lerpValue;
    public float sensibilidad;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
