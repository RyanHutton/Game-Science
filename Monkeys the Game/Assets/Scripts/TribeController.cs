using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribeController : MonoBehaviour {
    public int bananas = 0;
    public int population;
    public int numOfGatherers;
    public int numOfSoldiers;
    public bool underAttack;
    public GameObject monkey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (numOfGatherers + numOfSoldiers < population)
        {
            //AllocateUnits();
        }

        if (Input.GetKey("space")) //implement cycles, use timers?
        {
            SpawnUnits();
        }
	}

    void AllocateUnits()
    {
        while (numOfGatherers + numOfSoldiers < population)
        {
            //temp hardcoded assignments

        }
    }

    void SpawnUnits()
    {
        Vector3 spawnPoint = transform.position; //grabs position of hut
        spawnPoint.x += Random.Range(5f, 15f); //sets spawn of monkeys to be in a random range in front of the hut
        spawnPoint.z += Random.Range(-5f, 5f);
        GameObject unit = (GameObject)Instantiate(monkey, spawnPoint, transform.rotation);
        population++;

    }

    private void OnTriggerStay(Collider other)
    {
        if (underAttack == false)
        {
            underAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        underAttack = false;
    }
}
