using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Camera cam;
	public NavMeshAgent agent;
    
    public GameObject target;
    public GameObject hut;//hut's pivot
    public float temp;
    public float attackCooldown = 1f;
    UnitStats myStats;

    // Update is called once per frame, expensive, but just demo
    void Update () {
        myStats = GetComponent<UnitStats>();
        attackCooldown -= Time.deltaTime;
        temp = Mathf.Abs(Vector3.Distance(transform.position, hut.transform.position));
        if (myStats.currentHealth <= 0)
        {
            agent.SetDestination(hut.transform.position);//die
        }

		if (target != null)
        {
            agent.SetDestination(target.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < 2f)
            {
                if (attackCooldown <= 0f)
                {
                    Attack(target.GetComponent<UnitStats>());
                }                
            }
        }
        else
        {
            float distance = Mathf.Abs(Vector3.Distance(transform.position, hut.transform.position));
            if (distance < 8f)
            {
                //steal bananas
                Debug.Log(transform.name + " takes " +"banana!");
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

    void Attack (UnitStats targetStats)
    {
        if (targetStats.currentHealth <= 10)
        {
            RemoveTarget();
        }
        else
        {
            targetStats.TakeDamage(myStats.strength.GetValue());
            attackCooldown = 1f;
        }
        
    }
}
