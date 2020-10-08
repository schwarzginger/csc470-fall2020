using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        // transform.Translate(0.1f, 0, 0);

        float speed = 0.005f; 

        float x = transform.position.x + transform.forward.x * speed;
        float y = transform.position.y + transform.forward.y;
        float z = transform.position.z + transform.forward.z * speed;

        transform.position = new Vector3(x, y, z);


    }
}
