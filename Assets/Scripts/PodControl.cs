using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Class to handle the Escape Pod Computer Controls.
 * Takes input from input field, scrollbars, and "keycard scanner" button.
 */

public class PodControl : MonoBehaviour
{
    private float val1, val2, val3;

    public InputField input;
    public Scrollbar switch1, switch2, switch3;
    public Button keycardButton;

    private bool codeCorrect = false;
    private bool switchesCorrect = false;
    private bool cardScanned = false;

    public RoomTwo manager;

    void Update()
    {
        checkSwitches();
        //puzzles solved, go to win screen
        if(codeCorrect == true && switchesCorrect == true && cardScanned == true)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void checkLaunchCode(string code)
    {
        if(code == "8367")
        {
            input.image.color = Color.green;
            input.enabled = false;
            codeCorrect = true;
            
        }
    }

    public void firstSwitch (float value)
    {
        val1 = value;
    }
    public void secondSwitch(float value)
    {
        val2 = value;
    }

    public void thirdSwitch(float value)
    {
        val3 = value;
    }

    public void checkSwitches()
    {
        if(val1 == 1 && val2 == 1 && val3 == 0)
        {
            switchesCorrect = true;
            switch1.image.color = Color.green;
            switch2.image.color = Color.green;
            switch3.image.color = Color.green;
        }
    }

    public void scanKeycard()
    {
        if(manager.inv2.gameObject.activeSelf == true)
        {
            keycardButton.image.color = Color.green;
            cardScanned = true;
        }
    }
}
