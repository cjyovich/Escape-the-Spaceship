using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* 
 * Game Manager for Escape the Spaceship Room One.
 * This script manages object clicking (Raycast) and camera switching.
 */

public class RoomOne : MonoBehaviour {

    //public float force = 5;

    //cameras
    public Camera mainCamera; 
    public Camera computerScreen;
    public Camera ALECCamera;
    
    //inventory raw images
    public RawImage inv1;
    public RawImage inv2;

    //zoom on inventory items in the middle of the screen
    public RawImage zoom;

    public Texture screwdriver;
    public Texture notebook;

    public GameObject book;

    public ComputerManager computer;

    private void Start()
    {
        computerScreen.enabled = false;
        ALECCamera.enabled = false;
        book.SetActive(false);
        inv1.gameObject.SetActive(false);
        inv2.gameObject.SetActive(false);
        zoom.gameObject.SetActive(false);
    }
    private void Update()
    {
        //close computer, back to main cam
        if (computerScreen.enabled == true)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                computerScreen.enabled = false;
                mainCamera.enabled = true;
            }
        }

        //back to main cam from ALEC
        if(ALECCamera.enabled == true)
        {
            if(Input.GetButtonDown("Cancel"))
            {
                ALECCamera.enabled = false;
                mainCamera.enabled = true;
            }

        }

        //zoom on Inventory item one
        if(Input.GetKeyDown(KeyCode.F1))
        {
            zoom.texture = screwdriver;
            zoom.gameObject.SetActive(true);
        }

        //zome on Inventory item two
        if(Input.GetKeyDown(KeyCode.F2))
        {
            zoom.texture = notebook;
            zoom.gameObject.SetActive(true);
        }

        if(Input.GetButtonDown("Cancel"))
        {
            zoom.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) // Right mouse click
        {
            RaycastHit hit;                //Declare a RaycastHit variable
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //cast ray from mouse position

            if (Physics.Raycast(ray, out hit, 100.0f))    //use the ray to see what gets hit travelling 100 units
            {                          //The out hit is the output of the ray, what it hit
                if (hit.transform != null)  //If not null we hit something in 100 units
                {
                    //PrintName(hit.transform.gameObject);

                    if(hit.transform.tag == "ALEC") //switch to ALEC cam
                    {
                        ALECCamera.enabled = true;
                        mainCamera.enabled = false;
                    }

                    if(hit.transform.tag == "Computer") //switch to computer view
                    {

                        mainCamera.enabled = false;
                        computerScreen.enabled = true;
                        
                    }

                    if(hit.transform.tag == "Vent")
                    {
                        if(inv1.gameObject.activeSelf == true) //screwdriver is in inventory
                        {
                            GameObject vent = hit.transform.gameObject;
                            vent.SetActive(false);
                            book.SetActive(true);
                            inv1.gameObject.SetActive(false);
                        }
                    }

                    if(hit.transform.tag == "Screwdriver")
                    {
                        GameObject screwdriver = hit.transform.gameObject;
                        screwdriver.SetActive(false);
                        inv1.gameObject.SetActive(true);
                        GameControl.control.Save();
                    }

                    if(hit.transform.tag == "Journal")
                    {
                        GameObject journal = hit.transform.gameObject;
                        journal.SetActive(false);
                        inv2.gameObject.SetActive(true);

                    }

                    if(hit.transform.tag == "Door")
                    {
                        if (computer.isDoorOpen() == true)
                        {
                            GameControl.control.setRoom1();
                            GameControl.control.Save();
                            SceneManager.LoadScene(2);
                        }
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
