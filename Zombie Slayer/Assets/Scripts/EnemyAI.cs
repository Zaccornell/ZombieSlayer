using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Name of the script and monobehaviour is where the script can get its information from
public class EnemyAI : MonoBehaviour {

    //Reference to the NavMeshAgent and giving it a name
    private NavMeshAgent myAgent;

    //Naming the transform of this object to target
    public Transform target;

    //health is the ammount of health the enemy has
    public float health = 100;

    //enemyDamage is how much damage the enemy does
    public float enemyDamage = 30;

    //-----------------------------------
    //Start()
    // Use this for initialization
    //
    //Param:
    //      Void
    //-----------------------------------
    void Start() {
        //Getting components from the NavMeshAgent script
        myAgent = this.GetComponent<NavMeshAgent>();

        //If something is wrong write message into console otherwise(else) run the set destination function
        if (myAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to" + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    //----------------------------------
    //SetDestination()
    //Called at the start of the game
    //
    //Param:
    //
    //Return:
    //      Void
    //----------------------------------
    private void SetDestination()
    {
        //If target is not nothing then move to the set destination to targetVector
        if (target != null)
        {
            Vector3 targetVector = target.transform.position;
            myAgent.SetDestination(targetVector);
        }
    }

    //----------------------------------------
    //Update()
    // Update is called once per frame
    //
    //Param:
    //
    //Return
    //----------------------------------------
    void Update()
    {
        //Set the agent destination to the targeted position
        myAgent.SetDestination(target.position);
    }
    //-------------------------------------------
    //TakeDamage
    //
    //Param:
    //     float - float is a variable
    //     damage - is the name of the variable
    //Return
    //     Void
    //-------------------------------------------
    public void TakeDamage(float damage)
    {
        //health equals health then minus damage
        health = health - damage;

        //If health is less than or equal to zero then Destroy the game object this script is on
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //-----------------------------------------------------
    //OnTriggerEnter
    //Called when something enters the trigger
    //
    //Param:
    //     Collider - reference to the object collider
    //     other - means the otrher object in the collider
    //Return:
    //        Void
    //------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        //setting other as a tag called "Player" and if this object with the tag Player then take damage.
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DamageTaken(enemyDamage);
        }
    }

}