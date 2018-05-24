using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class AmmoPickUp : MonoBehaviour {

    //Reference to the gameobject
    public GameObject objectToDeactivate;

    //This is how much ammo you pick up
    public int ammo = 50;

    //-------------------------------------------------
    //OnTriggerEnter()
    //Called when the player enters the trigger
    //
    //Param:
    //   Collider - this is the collider of the object
    //   other is another object
    //Return
    //    Void
    //--------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        //Tagging the other as player
        if (other.tag == "Player")
        {
            Camera.main.GetComponent<FireRay>().AddAmmo(ammo);
            DeactivateObject();
        }
            
    }

private void DeactivateObject()
    {
        objectToDeactivate.SetActive(false);
    }
}
