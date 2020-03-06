using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controls the Main Menu of the Escape the Spaceship game.
 */
public class GUIControl : MonoBehaviour
{

    public Canvas settingsCanvas;
    public Canvas creditsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        settingsCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showSettingsCanvas()
    {
        settingsCanvas.enabled = true;
    }
    public void showCreditsCanvas()
    {
        creditsCanvas.enabled = true;
    }
    public void hideSettingsCanvas()
    {
        settingsCanvas.enabled = false;
    }
    public void hideCreditsCanvas()
    {
        creditsCanvas.enabled = false;
    }

    public void startGame()
    {
        //load save if exists
        GameControl.control.Load();
        if(GameControl.control.intro == false)
        {
            SceneManager.LoadScene(4);
        }
        else if (GameControl.control.room1 == true)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    //resets game data to "factory settings"
    public void resetData()
    {
        GameControl.control.resetRoom();
        GameControl.control.resetTimer();
        GameControl.control.Save();
    }

    public void toggleAudio()
    {
        print(AudioListener.volume);
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
    }
}
