using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    public static bool timerActive = false;
    float currentTime;
    public int startSeconds;
    public Text startText;

    void Start()
    {
        currentTime = startSeconds * 1;
        timerActive = true;
    }

    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            startText.text = time.Seconds.ToString();
        }

        if (currentTime <= 0)
            {
                timerActive = false;
                Score.State = true;
            }
    }
}
