using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Handles ALEC's dialogue in Level One. 
 */

public class DialogueManager : MonoBehaviour
{
    public Camera player;
    public Text dialogue;
    private RoomOne manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = player.GetComponent<RoomOne>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.inv2.gameObject.activeSelf == true)
        {
            dialogue.text = "That note you found is from the Captain's journal. Looks like a shift cipher.";
        }
        else
        {
            dialogue.text = "The door cannot be opened until you override the lockdown from the Captain's computer.";
        }
    }
}
