using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMover : MonoBehaviour
{

    float rotatespeed = 40f;
    float speed = 19f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotatespeed * Time.deltaTime, 0);


        //gameObject.transform.position = transform.position + transform.forward * Time.deltaTime;
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
