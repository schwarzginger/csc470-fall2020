using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookandFollow : MonoBehaviour
{

    public Transform aTarget;
    float a_speed = 10.0f; 
    Vector3 aLookDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aLookDirection = (aTarget.position - transform.position).normalized;
        transform.Translate(aLookDirection * Time.deltaTime * a_speed); 
    }
}
