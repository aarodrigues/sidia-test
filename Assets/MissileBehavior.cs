using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveMissile();
    }

    void MoveMissile()
    {
        /*if(transform.position.z >-300)*/
        Debug.Log(transform.position.z);
        float actual_position = transform.position.z;
        if (actual_position < 400)
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }
    }
}
