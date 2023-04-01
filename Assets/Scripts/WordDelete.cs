using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordDelete : MonoBehaviour
{
    public Canvas canvas;
    public WordManager wordManager;
    private float minYPosition = -320f;

    public GameObject wordPrefab;

    public AudioSource source;
    public AudioClip clip;
    public static int lives = 3;
    private int livesPass;

    void Update()
    {
        for (int i = 0; i < wordManager.words.Count; i++)
        {
            Word word = wordManager.words[i];
            RectTransform rectTransform = word.wordDisplay.text.GetComponent<RectTransform>();
            if (rectTransform.anchoredPosition.y < minYPosition)
            {
                wordManager.RemoveWord(word);
                Destroy(word.wordDisplay.gameObject);
                i--;
                source.PlayOneShot(clip);
                if (lives > 1)
                {
                    livesPass--;
                    lives = livesPass;
                }
                else
                {
                    source.PlayOneShot(clip);
                    Invoke("Exit", 2.3f);
                }
            }
        }
    }

    void Exit()
    { 
        SceneManager.LoadScene("Exit");
        livesPass = 3;
        lives = livesPass;
    }
}
