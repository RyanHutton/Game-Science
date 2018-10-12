using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    public GameObject target;
	public NavMeshAgent agent;

    UnitStats myStats;

	// Update is called once per frame, expensive, but just demo
	void Update () {
        myStats = GetComponent<UnitStats>();

        if (myStats.currentHealth <= 0)
        {

            Destroy(gameObject);//die
        }

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

    void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    void RemoveTarget()
    {
        target = null;
    }
}
