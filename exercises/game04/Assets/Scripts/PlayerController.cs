using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    float moveSpeed = 12;
    float rotateSpeed = 85;

    public CharacterController cc;

    bool prevIsGrounded = false;

    float yVelocity = 0;
    float jumpForce = 0.9f;
    float gravityModifier = 0.2f;

    public movingplatform PlatformAttachedTo;
	public movngplatform2 PlatformAttachedTo2;


    private int count;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        count = 0;

    }


    // Update is called once per frame

    void Update()
    {
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		//ROTATION

		transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);


		//DEALING WITH GRAVITY
		if (!cc.isGrounded)
		{ 
			yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

			if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
			{
				yVelocity = 0;
			}
		}
		else
		{
			if (!prevIsGrounded)
			{
				yVelocity = 0;
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				yVelocity = jumpForce;
			}
		}

		//TRANSLATION

		Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;


		amountToMove.y = yVelocity;

        if (PlatformAttachedTo != null)
        {
            amountToMove += PlatformAttachedTo.DistanceMoved;
        }
		if (PlatformAttachedTo2 != null)
		{
			amountToMove += PlatformAttachedTo.DistanceMoved;
		}
		cc.Move(amountToMove);

		prevIsGrounded = cc.isGrounded;
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            count = count + 1;
            Destroy(other.gameObject); 

        }

    }

}
