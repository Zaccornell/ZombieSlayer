using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRay : MonoBehaviour {

    public GameObject raycastMarker = null;

    //How much ammo is in the ammoCount without collecting any ammo pick ups
    public int ammoCount = 100;

    //How many bullets you can shoot after reloading
    public int clipSize = 15;

    //How many bullets the player can shoot before reloading
    public int clipCount = 15;

    
    public Text ammoText;
    public Text clipText;

    public float timeBetweenBullets = 0.2f;
    private bool canShoot = true;

    public GameObject player;
    public float timeBetweenAttacks = 0.2f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;

    private bool isGameEnded;


    void Start()
    {
        UpdateText();
    }

    private void ResetShooting()
    {
        canShoot = true;
    }

    private void UpdateText()
    {
        ammoText.text = ammoCount.ToString();
        clipText.text = clipCount.ToString();
    }

    private void Reload()
    {
        ammoCount += clipCount;

        if (ammoCount > clipSize)
        {
            clipCount = clipSize;
            ammoCount -= clipSize;
        }
        else
        {
            clipCount = ammoCount;
            ammoCount = 0;
        }
        UpdateText();
    }
 
    // Use this for initialization
    void Update()
    {

        //A physics hit object to store info we are going  to get about where then ray hit.
        RaycastHit hit;

        //the distance of the ray we are using.
        float distanceOfRay = 100;

        //Cast the ray and check if it hits anything.
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceOfRay))
        {
            //Debug.Log(hit.transform.name);
        }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        //When left mouse is clicked
        if (Input.GetMouseButton(0))
        {
            //If clip is empty dont fire
            if (clipCount <= 0)
            {
                return;
            }


            if (canShoot == false)
            {

                return;
            }

            if(isGameEnded == true)
            {
                return;
            }
            clipCount--;
            UpdateText();

            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);

            GameObject GO = Instantiate(bulletPrefab, transform.position,
            Camera.main.transform.rotation) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(GO.transform.forward * 3000);


            Destroy(GO, 3f); canShoot = false;
            Invoke("ResetShooting", timeBetweenAttacks);

            raycastMarker.transform.position = hit.point;

            //raycastMarker.GetComponentInChildren<ParticleSystem>().Play()

            //Draw a ray in the editor
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);

        }


    }

    public void AddAmmo(int number)
    {
        ammoCount += number;
        UpdateText();

    }
    public void EndGame()
    {
        isGameEnded = true;
    }
}

