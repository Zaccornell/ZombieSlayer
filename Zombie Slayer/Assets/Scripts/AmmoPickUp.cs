using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class AmmoPickUp : MonoBehaviour {

    public GameObject objectToDeactivate;
    public float interactDelay = 0;
    public int ammo = 50;

    private void OnTriggerEnter(Collider other)
    {
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
