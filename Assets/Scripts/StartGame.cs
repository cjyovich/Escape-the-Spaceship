using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Handles the "begin" button on the intro screen.
 */
public class StartGame : MonoBehaviour
{
    public void startButton()
    {
        GameControl.control.setIntro();
        GameControl.control.Save();
        SceneManager.LoadScene(1);
    }
}
