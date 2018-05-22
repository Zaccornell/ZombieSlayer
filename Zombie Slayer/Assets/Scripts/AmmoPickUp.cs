using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TriggerDisplay))]
public class AmmoPickUp : MonoBehaviour {

    public GameObject objectToDeactivate;
    public float interactDelay = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("DeactivateObject", interactDelay);
        }
            
    }

private void DeactivateObject()
    {
        objectToDeactivate.SetActive(false);
    }
}
