using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public GameObject winText;
    public GameObject loseText;
    public static bool State;

    AudioSource audioSource;
    public AudioSource backgroundMusic;

    public Text ScoreTest;
    
    void Start()
    {
        scoreValue = 0;
        State = false;
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ScoreTest.text = scoreValue.ToString();
        if (Score.scoreValue == 5)
        {
            Timer.timerActive = false;
            backgroundMusic.Stop();
            winText.gameObject.SetActive(true);
            loseText.gameObject.SetActive(false);
        }

        if (State == true)
        {
            backgroundMusic.Stop();
            loseText.gameObject.SetActive(true);
            winText.gameObject.SetActive(false);
        }
    }
}
