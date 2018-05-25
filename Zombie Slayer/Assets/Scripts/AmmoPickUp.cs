using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]

//Name of the script and monobehaviour is where the script can get its information from
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
            //Add ammo to camera
            Camera.main.GetComponent<FireRay>().AddAmmo(ammo);

            //If aboce is true deactivate object
            DeactivateObject();
        }
            
    }

    //-------------------------------------------------------------------------
    //DeactivateObject()
    //Called when the object tagged "Player" enters the object collider
    //
    //Param:
    //
    //Return:
    //      Void
    //-------------------------------------------------------------------------
private void DeactivateObject()
    {
        //When the function is running set this to false
        objectToDeactivate.SetActive(false);
    }
}
