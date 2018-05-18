using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrenade : MonoBehaviour {

    public GameObject grenadeLaunchPoint;
    public GameObject flowerGrenade;
    public float launchPower = 2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //If the player presses the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //Create a grendade
            GameObject GO = Instantiate(flowerGrenade,
                grenadeLaunchPoint.transform.position, Quaternion.identity) as GameObject;

            //Add force to the grenade's rigidbody to push it forward
            GO.GetComponent<Rigidbody>().AddForce(
                grenadeLaunchPoint.transform.forward * launchPower, ForceMode.Impulse);
        }
		
	}
}
