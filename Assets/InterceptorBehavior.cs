using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorBehavior : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInterceptor();
    }

    void MoveInterceptor()
    {
        Debug.Log(transform.position.z);
        float actual_position = transform.position.z;
        float cornerAngle = 7.4f;
        transform.Translate(speed * Vector3.back * Mathf.Cos(cornerAngle) * Time.deltaTime);
        //Vector2 currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + center;

    }
}
