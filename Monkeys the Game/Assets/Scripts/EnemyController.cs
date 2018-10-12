using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Camera cam;
	public NavMeshAgent agent;
    
    public GameObject target;
    public GameObject hutPivot;
    public GameObject hut;

    public float cooldown = 1f;
    UnitStats myStats;

    // Update is called once per frame, expensive, but just demo
    void Update () {
        myStats = GetComponent<UnitStats>();
        cooldown -= Time.deltaTime;

        if (myStats.currentHealth <= 0)
        {
            agent.SetDestination(hut.transform.position);//die
        }

		if (target != null)
        {
            agent.SetDestination(target.transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < 3f)//2f when not clumped?
            {
                if (cooldown <= 0f)
                {
                    Attack(target.GetComponent<UnitStats>());
                }                
            }
        }
        else
        {
            float distance = Mathf.Abs(Vector3.Distance(transform.position, hutPivot.transform.position));
            if (distance < 7f)
            {
                if (cooldown <= 0f)
                {
                    Steal(hut.GetComponent<UnitStats>());//steal bananas
                    Debug.Log(transform.name + " takes " + "banana!");
                }
            }
            else
            {
                agent.SetDestination(hutPivot.transform.position);

            }
        }
	}

    void OnTriggerStay(Collider col)
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
        if (targetStats.currentHealth <= 0)
        {
            RemoveTarget();
        }
        else
        {
            targetStats.TakeDamage(myStats.strength.GetValue());
            cooldown = 1f;
        }
        
    }

    void Steal (UnitStats hutStats)
    {
        hutStats.TakeFood(myStats.gather.GetValue());
        myStats.food.SetValue(myStats.food.GetValue() + myStats.gather.GetValue());//change this later to reflect actual amount stolen
        cooldown = 1f;
    }
}
