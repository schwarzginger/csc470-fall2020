using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{

	public GameObject slot;
	float xtemp;
	float ytemp;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{


	}

	void OnMouseUp()
	{
		if (Vector3.Distance(transform.position, slot.transform.position) == 1)
		{
			xtemp = transform.position.x;
			ytemp = transform.position.y;
			transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, 0f);
			slot.transform.position = new Vector3(xtemp, ytemp, 0f);
		}
	}


}
