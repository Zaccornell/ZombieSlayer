using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireRay : MonoBehaviour {

    public GameObject raycastMarker = null;

    public int ammoCount = 100;
    public int clipSize = 15;
    public int clipCount = 5;

    public Text ammoText;
    public Text clipText;

    public float timeBetweenBullets = 0.2f;
    private bool canShoot = true;


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

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
        //When mouse is clicked
        if (Input.GetMouseButton(0))
        {
            if (clipCount <= 0)
            {
                return;
            }

            if (canShoot == false)
            {
                return;
            }

            canShoot = false;
            Invoke("ResetShooting", timeBetweenBullets);

            clipCount--;
            UpdateText();

            raycastMarker.transform.position = hit.point;
            raycastMarker.GetComponentInChildren<ParticleSystem>().Play();

            Debug.Log(hit.point);

            //Pushes object up.
            //hit.transform.position = hit.transform.position + Vector3.up;

            //Shrinks object. (scale object)
            //hit.transform.localScale = hit.transform.localScale * 0.9f;

            // deactivates the object (makes it dissapear)
            // hit.transform.gameObject.SetActive(false);

            // Destroys the object.
            //Destroy(hit.transform.gameObject);

            //Change colour of the object
            // hit.transform.gameObject.GetComponent<Renderer>().material.color =
            // new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        //Draw a ray in the editor
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);
    }

}
