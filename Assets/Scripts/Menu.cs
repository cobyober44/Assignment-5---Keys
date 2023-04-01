using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public InputField playerName;
    public Text nameText;
    public static string myName = "You";

    private int resetLives = 3;

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        WordDelete.lives = resetLives;
    }

    public void InputName()
    {
        myName = playerName.text.ToString();
        nameText.text = myName.ToUpper();
    }

}
