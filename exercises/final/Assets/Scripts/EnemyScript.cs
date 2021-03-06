﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public float area;
    private Vector2 newWayPoint;
    private Vector3 wayPoint;
    private Vector3 oldWayPoint;
    public float timeSmooth;
    private float time;
    private CharacterController controller;
    // Use this for initialization
    void Start()
    {
        newWayPoint = Random.insideUnitCircle * area;
        wayPoint = new Vector3(newWayPoint.x, transform.position.y, newWayPoint.y);
        controller = GetComponent<CharacterController>();
        oldWayPoint = wayPoint;
    }

    // Update is called once per frame
    void Update()
    {


        MoveRandomly();



    }

    void MoveRandomly()
    {

        Vector3 smoothLookAt = Vector3.Slerp(oldWayPoint, wayPoint, time / timeSmooth);
        time += Time.deltaTime;
        smoothLookAt.y = wayPoint.y;


        if (Vector3.Distance(transform.position, wayPoint) > 20.0f && time / timeSmooth < 1.0f)
        {
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            newWayPoint = Random.insideUnitCircle * area;
            oldWayPoint = wayPoint;
            wayPoint = new Vector3(newWayPoint.x, wayPoint.y, newWayPoint.y);
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
            time = 0;
        }
    }

}
