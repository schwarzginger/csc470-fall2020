using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMove : MonoBehaviour
{

    float rotatespeed = 40f;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotatespeed * Time.deltaTime, 0);
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
