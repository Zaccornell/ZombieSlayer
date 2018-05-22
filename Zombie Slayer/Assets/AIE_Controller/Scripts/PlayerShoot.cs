using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShoot : MonoBehaviour {

    public float timeBetweenAttacks = 0.2f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public bool canShoot = true;

	// Use this for initialization
	void Start ()
    {
       
	}
	
    public void Attack(Vector3 attackLocation)
    {
        if (canShoot)
        {
            GameObject GO = Instantiate(bulletPrefab, transform.position,
                Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce((attackLocation - transform.position)
                * bulletSpeed, ForceMode.Impulse);

            Destroy(GO, 3f);canShoot = false;
            Invoke("ResetShooting", timeBetweenAttacks);
        }
    }
    private void ResetShooting()
    {
        canShoot = true;
    }
}
