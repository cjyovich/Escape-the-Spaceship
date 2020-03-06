using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * Game Manager for Escape the Spaceship Room Two.
 * This script manages object clicking (Raycast) and camera switching.
 */

public class RoomTwo : MonoBehaviour
{

    //cameras
    public Camera mainCamera;
    public Camera computerScreen;
    public Camera PodCamera;

    //inventory zoom textures
    public Texture keycard;
    public Texture extinguish;
    public Texture manual;

    //inventory raw images
    public RawImage inv1;
    public RawImage inv2;
    public RawImage inv3;

    public RawImage zoom;

    public ParticleSystem fire;

    public CaptainComputer computer;

    private void Start()
    {
        computerScreen.enabled = false;
        PodCamera.enabled = false;
        inv1.gameObject.SetActive(false);
        inv2.gameObject.SetActive(false);
        inv3.gameObject.SetActive(false);
        zoom.gameObject.SetActive(false);
    }
    private void Update()
    {
        //close computer, back to main cam
        if (computerScreen.enabled == true)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                computerScreen.enabled = false;
                mainCamera.enabled = true;
            }
        }

        //back to main cam from escape pod computer
        if (PodCamera.enabled == true)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                PodCamera.enabled = false;
                mainCamera.enabled = true;
            }

        }

        //zoom on Inventory item one
        if (Input.GetKeyDown(KeyCode.F1))
        {
            zoom.texture = extinguish;
            zoom.gameObject.SetActive(true);
        }

        //zoom on Inventory item two
        if (Input.GetKeyDown(KeyCode.F2))
        {
            zoom.texture = keycard;
            zoom.gameObject.SetActive(true);
        }
        //zoom on Inventory item three
        if (Input.GetKeyDown(KeyCode.F3))
        {
            zoom.texture = manual;
            zoom.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            zoom.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) // Right mouse click
        {
            RaycastHit hit;                //Declare a RaycastHit variable
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //cast a ray from mouse position

            if (Physics.Raycast(ray, out hit, 100.0f))    //use the ray to see what gets hit travelling 100 units
            {                          //The out hit is the output of the ray, what it hit
                if (hit.transform != null)  //If not null we hit something in 100 units
                {
                    //PrintName(hit.transform.gameObject);

                    if (hit.transform.tag == "ControlPanel") //switch to escape pod cam
                    {
                        PodCamera.enabled = true;
                        mainCamera.enabled = false;
                    }
                    if (hit.transform.tag == "Computer") //switch to computer cam
                    { 
                        mainCamera.enabled = false;
                        computerScreen.enabled = true;
                    }

                    if(hit.transform.tag == "extinguisher")
                    {
                        GameObject extinguisher = hit.transform.gameObject;
                        extinguisher.SetActive(false);
                        inv1.gameObject.SetActive(true);
                    }

                    if(hit.transform.tag == "FirePlane") //use extinguisher to put out fire in hallway
                    {
                        if(inv1.gameObject.activeSelf == true) //if extinguisher is in inventory
                        {
                            Destroy(hit.transform.gameObject);
                            Destroy(fire);
                            inv1.gameObject.SetActive(false);
                        }
                    }

                    if(hit.transform.tag == "keycard")
                    {
                        GameObject keycard = hit.transform.gameObject;
                        keycard.SetActive(false);
                        inv2.gameObject.SetActive(true);
                    }

                    if(hit.transform.tag == "Bookcase")
                    {
                        inv3.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

}