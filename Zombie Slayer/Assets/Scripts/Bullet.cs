using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Name of the script and monobehaviour is where the script can get its information from
public class Bullet : MonoBehaviour {

    //This is how much damage the bullet does
    public float damage = 35;

    //-----------------------------------------------------------------
    //OnTriggerEnter()
    //When something enetersw the trigger
    //
    //Param: 
    //OnTriggerEnter(Collider other) - this is the collider of the bullet
    //
    //return:
    //     Void
    //---------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        //this is setting other as a tag which is named "Enemy"
        if (other.tag == "Enemy")
        {
            //refrencing the TakeDamage function from the EnemyAI script and doing damage
            other.GetComponent<EnemyAI>().TakeDamage(damage);

            //When above is done Destroy the game object the script is on
            Destroy(this.gameObject);
        }
    }
}
