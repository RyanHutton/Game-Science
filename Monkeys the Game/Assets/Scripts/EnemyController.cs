﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Camera cam;
	public NavMeshAgent agent;
    public int aggression;
    public int gather;
    public int strength;
    public int fitness;
	// Update is called once per frame, expensive, but just demo
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray =  cam.ScreenPointToRay(Input.mousePosition);//should use viewport, but is demo
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }


        }
	}
}