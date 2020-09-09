using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterflycontroller : MonoBehaviour
{

    //public GameObject thingtoChase;
    //public Transform objectToFollow;
    //public Vector3 offset;

    public Transform objectToFollow;
    public float speed = 1.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, step);


        if (Vector3.Distance(transform.position, objectToFollow.position) < 0.001f)
        {

            objectToFollow.position *= -1.0f;



        }

    }


}

