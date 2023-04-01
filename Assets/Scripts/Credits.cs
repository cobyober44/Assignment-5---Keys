using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text playerName;
    
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Awake()
    {
        playerName.text = Menu.myName;
    }
}


