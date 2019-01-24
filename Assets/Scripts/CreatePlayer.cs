using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject[] vehicles;
    public Material[] carColors;
    public Material[] truckColors;
    public Material[] suvColors;
    
	void Start ()
    {
        int choice = Random.Range(0, vehicles.Length);
        GameObject player = Instantiate(vehicles[choice]);
        if (choice == 0)
            player.transform.GetChild(0).GetComponent<MeshRenderer>().material = carColors[Random.Range(0, carColors.Length)];
        if (choice == 1)
            player.transform.GetChild(0).GetComponent<MeshRenderer>().material = truckColors[Random.Range(0, truckColors.Length)];
        if (choice == 2)
            player.transform.GetChild(0).GetComponent<MeshRenderer>().material = suvColors[Random.Range(0, truckColors.Length)];
        transform.parent = player.transform;
        Destroy(this);
	}
}
