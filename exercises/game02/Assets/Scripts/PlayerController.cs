using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{

    
    float rotatespeed = 150f;
    float speed = 35f;
    int score = 0;
    Rigidbody m_Rigidbody;

    public Text scoretext;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
        }







        //float hAxis = Input.GetAxis("Horizontal");
        //transform.Rotate(0, hAxis * rotatespeed * Time.deltaTime, 0, Space.World);


        ////gameObject.transform.position = transform.position + transform.forward * Time.deltaTime;
        //transform.Translate(transform.forward * Time.deltaTime * speed);

        //if (speed > 0)
        //{
        //    speed -= 4 * Time.deltaTime;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    speed += 5;
        //}
        //speed = Mathf.Clamp(speed, 0, 15);




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eggs"))
        {

            //EggScript egg = other.gameObject.GetComponent<EggScript>();
            //if (!egg.chaseDragon)
            //{


            Destroy(other.gameObject);

            score++;
            scoretext.text = score.ToString();


            //}
        }  

    }
    
}
