using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private float timeLimit;
    [HideInInspector] public bool isTimeRunning;
    private float timeRemaining;

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
        text.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        if (!isTimeRunning) return;

        isTimeRunning = false;
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isTimeRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTimer(timeRemaining);
        }
        else StopTimer();
    }

    private void DisplayTimer(float _timerRemaining)
    {
        TimeSpan time = TimeSpan.FromSeconds(_timerRemaining);
        text.text = time.ToString("mm':'ss");
    }
}