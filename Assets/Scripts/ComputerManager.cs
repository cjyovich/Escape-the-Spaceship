using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Class to handle the computer in Room One - lockdown and door unlock.
 */

public class ComputerManager : MonoBehaviour
{
    public Text logonText;
    public Text input;

    public Button lockdown;
    public Button door;

    public GameObject lights;
    public AudioSource siren;

    private bool doorOpen = false;

    void Start()
    {
        logonText.enabled = false;
        lockdown.interactable = false;
        door.interactable = false;
    }

    public void checkPassword (string newText)
    {
        string correctPassword = "andromeda";

        if (newText.CompareTo(correctPassword) == 0)
        {
            logonText.enabled = true;
            input.enabled = false;
            lockdown.interactable = true;
        }
    }

    public void lockdownOverride ()
    {
        door.interactable = true;
        lockdown.interactable = false;
        lights.SetActive(false);
        siren.enabled = false;
    }

    public void doorUnlock()
    {
        doorOpen = true;
    }

    public bool isDoorOpen()
    {
        return doorOpen;
    }
}
