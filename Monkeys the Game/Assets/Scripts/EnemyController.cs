using System.Collections;
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
    public GameObject target;
    public GameObject hut;

    // Update is called once per frame, expensive, but just demo
    void Update () {
		if (target != null)
        {
            agent.SetDestination(target.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < 2f)
            {
                GetComponent<Material>().color = Color.yellow;//attack placeholder
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, hut.transform.position);
            if (distance < 10f)
            {
                //steal bananas
            }
            else
            {
                agent.SetDestination(hut.transform.position);

            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (target == null && col.gameObject.tag == "Monkey")//
        {
            SetTarget(col.gameObject);
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
