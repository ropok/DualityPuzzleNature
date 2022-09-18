using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLimit;
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
        UIManager.instance.TimerText.gameObject.SetActive(true); // maybe should be done on UIManager?
    }

    public void StopTimer()
    {
        if (!isTimeRunning) return;

        isTimeRunning = false;
        UIManager.instance.TimerText.gameObject.SetActive(false);
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
        UIManager.instance.TimerText.text = timerString;
    }
}