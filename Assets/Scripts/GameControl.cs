using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

/*
 * Game Control handles data persistence.
 */

public class GameControl : MonoBehaviour
{
    public static GameControl control;

    //variables we want to save
    public float timer = 1800;
    public bool intro = false;
    public bool room1 = false;

    private float halfScreen;
    
    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }

        halfScreen = (Screen.width / 2) - 75;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        //"pauses" time during main menu, intro, and win screen
        //time only counts down during level one and two
        if(SceneManager.GetActiveScene().name == "StartScreen" || SceneManager.GetActiveScene().name == "IntroScreen" || SceneManager.GetActiveScene().name == "WinScreen")
        {
            Time.timeScale = 0;
            
        }
        else
        {
            Time.timeScale = 1;
        }

        //save and quit to main menu during game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            control.Save();
            SceneManager.LoadScene(0);
        }
    }

    //countdown timer and final time on end screen
    private void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string timeLeft = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (SceneManager.GetActiveScene().name == "LevelOne" || SceneManager.GetActiveScene().name == "LevelTwo")
        {
            GUI.Label(new Rect(halfScreen, 10, 150, 30), "Time Remaining: " + timeLeft);
        }

        if (SceneManager.GetActiveScene().name == "WinScreen")
        {
            float escapetime = 1800 - timer;
            int minutesPassed = Mathf.FloorToInt(escapetime / 60F);
            int secondsPassed = Mathf.FloorToInt(escapetime - minutesPassed * 60);
            string finalTime = string.Format("{0:00}:{1:00}", minutesPassed, secondsPassed);
            GUI.Label(new Rect(halfScreen, 500, 150, 30), "You escaped in " + finalTime);
        }
    }

    public void setIntro()
    {
        intro = true;
    }
    public void setRoom1()
    {
        room1 = true;
    }
    
    public void resetTimer()
    {
        timer = 1800;
    }

    public void resetRoom()
    {
        intro = false;
        room1 = false;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerData data = new PlayerData();
        data.timer = timer;
        data.intro = intro;
        data.room1 = room1;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            timer = data.timer;
            intro = data.intro;
            room1 = data.room1;
            
        }
    }
}

[Serializable]
class PlayerData
{
    public float timer;
    public bool intro;
    public bool room1;
}
