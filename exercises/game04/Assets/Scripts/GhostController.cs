using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GhostController : MonoBehaviour
{
	public Rigidbody rb;

	public GameObject minighostPrefab;


	float speed = 10;
	float maxSpeed = 15;
	float forwardSpeed = 10;
	float pitchSpeed = 80;
	float pitchModSpeedRate = 10f;
	float rollSpeed = 80;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		// Rotate the plane based on input.
		float xRot = vAxis * pitchSpeed * Time.deltaTime;
		float yRot = hAxis * rollSpeed / 4 * Time.deltaTime;
		float zRot = -hAxis * rollSpeed * Time.deltaTime;
		transform.Rotate(xRot, yRot, zRot, Space.Self);

		forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;

		forwardSpeed = Mathf.Clamp(forwardSpeed, 0, 5f);


		transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);


		if (forwardSpeed <= 0.01f)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
		}


		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		if (transform.position.y < terrainHeight)
		{
			transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject minighost = Instantiate(minighostPrefab, transform.position * 1 + transform.forward * 3, Quaternion.identity);
			Rigidbody minighostRB = minighost.GetComponent<Rigidbody>();
			minighostRB.AddForce(transform.forward * 6000);
			Destroy(minighost, 7);
		}


        Vector3 cameraPosition = transform.position - (transform.forward * 12 + Vector3.up * 5);
        Camera.main.transform.position = cameraPosition;
        Vector3 lookAtPos = transform.position + transform.forward * 8;

        // Rotate the camera so that it looks always in front of the plane.
        Camera.main.transform.LookAt(lookAtPos, Vector3.up);

    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("spiderweb"))
		{
			speed = Mathf.Clamp(speed + 5, 0, maxSpeed);
		}
	}
}
