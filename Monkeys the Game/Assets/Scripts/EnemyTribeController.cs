using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTribeController : MonoBehaviour {
    
    public int population;
    public int maxEnemies;
    public GameObject monkey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		

        if (population < maxEnemies) //implement cycles, use timers?
        {
            SpawnUnits();
        }
	}

    void SpawnUnits()
    {
        Vector3 spawnPoint = transform.position; //grabs position of hut
        spawnPoint.x += Random.Range(-5f, 5f); //sets spawn of monkeys to be in a random range in front of the hut
        spawnPoint.z += Random.Range(-5f, -15f);
        GameObject unit = (GameObject)Instantiate(monkey, spawnPoint, transform.rotation);
        population++;

    }
}
