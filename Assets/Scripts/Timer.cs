using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    [SerializeField] private Text timerText;
    private bool isTimeRunning;
    [HideInInspector] public float timeRemaining;

    private void Awake()
    {
        isTimeRunning = false;
        timeRemaining = timeLimit;
    }

    public void StartTimer()
    {
        if (isTimeRunning) return;

        timeRemaining = timeLimit;
        isTimeRunning = true;
        timerText.gameObject.SetActive(true); // maybe should be done on UIManager?
    }

    public void StopTimer()
    {
        if (!isTimeRunning) return;

        isTimeRunning = false;
        timerText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isTimeRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
            DisplayTimer(time.ToString("mm':'ss"));
        }
        else StopTimer();
    }

    void DisplayTimer(string timerString)
    {
        timerText.text = timerString;
    }
}