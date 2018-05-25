using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Name of the script and monobehaviour is where the script can get its information from
public class FireRay : MonoBehaviour {
    //
    public GameObject raycastMarker = null;

    //How much ammo is in the ammoCount without collecting any ammo pick ups
    public int ammoCount = 100;

    //How many bullets you can shoot after reloading
    public int clipSize = 15;

    //How many bullets the player can shoot before reloading
    public int clipCount = 15;

    //Reference to the text in the hirearchy
    public Text ammoText;
    public Text clipText;

    //Time between each bullet
    public float timeBetweenBullets = 0.2f;

    //Sets can shoot to true
    private bool canShoot = true;

    //this is a gameobject in the scene
    public GameObject player;

    //The time when I am unable to shoot
    public float timeBetweenAttacks = 0.2f;

    //This is the bullet prefab game object
    public GameObject bulletPrefab;

    //How fast the bullet can travel
    public float bulletSpeed = 5f;

    //Runs when game is ended
    private bool isGameEnded;


    //-------------------------------
    //Start()
    //Use this for initialization
    //
    //Param:
    //
    //Return
    //     Void
    //-------------------------------
    void Start()
    {
        //This updates the text
        UpdateText();
    }

    //---------------------------
    //ResetShooting
    //Makes canShoot true
    //
    //Param:
    //
    //Return:
    //      Void
    //----------------------------
    private void ResetShooting()
    {
        //Sets can shoot to true
        canShoot = true;
    }

    //-----------------------------------------
    //UpdateText()
    //Called when I need to update the text
    //
    //Param:
    //
    //Return:
    //      Void
    //------------------------------------------
    private void UpdateText()
    {
        //Makes text equal to ammoCount and makes ammo count a string
        ammoText.text = ammoCount.ToString();

        //Makes text equal to clipCount and makes ammo count a string
        clipText.text = clipCount.ToString();
    }

    //--------------------------------------------
    //Reload()
    //
    //Param:
    //
    //Return:
    //     Void
    //--------------------------------------------
    private void Reload()
    {
        //ammoCount more than or equal to clipCount
        ammoCount += clipCount;

        //If ammoCount is more than clipSize then clipCount is equal to clip size and ammoCount is less than or equal to clipSize
        if (ammoCount > clipSize)
        {
            clipCount = clipSize;
            ammoCount -= clipSize;
        }
        else
        //otherwise clipCount is equal to ammoCount and ammoCount equal to 0
        {
            clipCount = ammoCount;
            ammoCount = 0;
        }
        //update the text
        UpdateText();
    }
    
    //-----------------------------------
    //Update()
    // Use this for initialization
    //
    //Param:
    //
    //Return:
    //      Void
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

        //If the R key is pressed run the Reload() function
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

            //If canShoot equals false dont do anything under it
            if (canShoot == false)
            {

                return;
            }

            //If isGameEnded equal true dont do anything under the wrod return
            if(isGameEnded == true)
            {
                return;
            }

            //clipCount is decreased by pressing left click then update text
            clipCount--;
            UpdateText();

            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);

            //Spawn the bullet prefab at the main camera
            GameObject GO = Instantiate(bulletPrefab, transform.position,
            Camera.main.transform.rotation) as GameObject;

            //Add force to the bullet object
            GO.GetComponent<Rigidbody>().AddForce(GO.transform.forward * 3000);

            //Destroy the game object after 3 seconds
            Destroy(GO, 3f);
            
            canShoot = false;
            Invoke("ResetShooting", timeBetweenAttacks);

            //Makes raycast marker's position equal to the hit.point
            raycastMarker.transform.position = hit.point;

            //Displays particle system
            //raycastMarker.GetComponentInChildren<ParticleSystem>().Play()

            //Draw a ray in the editor
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);

        }


    }

    //--------------------------------
    //AddAmmo()
    //
    //param:
    //int - is a number
    //number - is the name I gave it
    //Return
    //     Void
    //--------------------------------
    public void AddAmmo(int number)
    {
        //ammoCount is more or equal to number update the text
        ammoCount += number;
        UpdateText();

    }
    //---------------------------------
    //EndGame()
    //Called when the player dies
    //
    //Param:
    //
    //Return
    //      Void
    //--------------------------------
    public void EndGame()
    {
        //When the game ends make this true
        isGameEnded = true;
    }
}

