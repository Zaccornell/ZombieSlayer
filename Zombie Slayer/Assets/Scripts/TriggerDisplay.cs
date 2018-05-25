using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

//Name of the script and monobehaviour is where the script can get its information from
public class TriggerDisplay : MonoBehaviour
{

    void OnDrawGizmos()
    {
        //Saying box collider is a trigger and is set to true
        GetComponent<BoxCollider>().isTrigger = true;
        Vector3 drawBoxVector = new Vector3(
            this.transform.lossyScale.x * this.GetComponent<BoxCollider>().size.x,
            this.transform.lossyScale.y * this.GetComponent<BoxCollider>().size.y,
            this.transform.lossyScale.z * this.GetComponent<BoxCollider>().size.z
            );
        //draws the box in the set position
        Vector3 drawBoxposition = this.transform.position + this.GetComponent<BoxCollider>().center;

        //This is what actually draws the box
        Gizmos.matrix = Matrix4x4.TRS(drawBoxposition, this.transform.rotation, drawBoxVector);
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }


}

