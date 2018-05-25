using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Name of the script and monobehaviour is where the script can get its information from
public class PlayerHealth : MonoBehaviour {

    //The maximum amount of health the player can have
    private float playerMaxHealth = 100;

    //How much the health will regenerate
    private float regeneration = 15;
    
    //The current health the player has
    public float currentHealth = 100;

    //The time that is left remaining
    private float timeRemaining;
    
    //--------------------------------
    //Start()
	// Use this for initialization
    //
    //Param:
    //
    //Return:
    //     Void
    //--------------------------------
	void Start () {
		
	}

	//---------------------------------
    //Update
	// Update is called once per frame
    //
    //Param
    //
    //Return
    //     Void
    //----------------------------------
	void Update () {
        //
        timeRemaining = timeRemaining - Time.deltaTime;

        //If current health is less than or equal to 100 {do this}
        if (currentHealth >= 100)
        {
            currentHealth = 100;
            return;
        }

        //If timeRemaining is less than 0 {do this}
        if (timeRemaining < 0)
        {
            currentHealth += regeneration;

            //timeRemaining is equal to 1 second
            timeRemaining = 1f;
        }
		
	}
    //----------------------------------------------------------------------
    //damageTaken()
    //Called when damage is taken
    //
    //Param:
    //float damage - is a reference to the damage float in the bullet script
    //
    //Return
    //     Void
    //----------------------------------------------------------------------
    public void DamageTaken(float damage)
    {
        //If currentHealth is less than or equal to 0 thewn dont do anything under return
        if (currentHealth <= 0)
        {
            return;
        }
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
             // Finding game object thats in the hierarchy
                GameObject player = GameObject.Find("FPS_Player");

            //Refrencing the EndGame function from the FPS_Player script
                player.GetComponent<FPS_Player>().EndGame();

            // Finding game object thats in the hierarchy
            GameObject shootScript = GameObject.Find("Camera_POV");

            //Refrencing the EndGame function from the FireRay script
                shootScript.GetComponent<FireRay>().EndGame();

            //Write in the console "You are dead
                Debug.Log("You are dead!");
            }
    }
}
