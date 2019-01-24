using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoad : MonoBehaviour
{
    public GameObject[] availableRoads;
    public GameObject[] availableStops;

    public GameObject nextSegment;
    private Transform spawnPoint;
    public int DCToSpawnStop;
    public float distanceToSpawnNextRoad;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Vector3.Distance(transform.position, nextSegment.transform.position) < distanceToSpawnNextRoad)
            Create();
	}

    void Create()
    {
        int roll = Random.Range(1, 101);
        spawnPoint = nextSegment.transform.GetChild(0).GetChild(1);
        if (roll < DCToSpawnStop)
        {
            nextSegment = Instantiate(availableRoads[Random.Range(0, availableRoads.Length)], spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            nextSegment = Instantiate(availableStops[Random.Range(0, availableStops.Length)], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
