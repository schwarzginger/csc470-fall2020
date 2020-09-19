using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public bool chaseDragon = false;
    GameObject Dragon;

    // Start is called before the first frame update
    void Start()
    {

        Dragon = GameObject.Find("Dragon");
    }

    // Update is called once per frame
    void Update()
    {

        if (chaseDragon) { 
        

            Vector3 directionToDragon = Dragon.transform.position - transform.position;
            directionToDragon = directionToDragon.normalized;

            transform.Translate(directionToDragon * Time.deltaTime * 6);
        }
    }
}
