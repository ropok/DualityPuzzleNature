using ChoosingVacation.Events;
using ChoosingVacation.ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ChoosingVacation
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private FloatValue timeLimit;
        [SerializeField] private FloatValue timeRemaining;
        [SerializeField] private EnumValue gameStatus;
        [SerializeField] private GameEvent endLevel;

        private bool isTimeRunning;

        private void Awake()
        {
            ResetTimer();
        }

        public void ResetTimer()
        {
            isTimeRunning = false;
            timeRemaining.Value = timeLimit.Value;
        }

        public void StartTimer()
        {
            if (isTimeRunning) return;

            timeRemaining.Value = timeLimit.Value;
            isTimeRunning = true;
        }

        public void StopTimer()
        {
            if (!isTimeRunning) return;

            isTimeRunning = false;
            endLevel.Raise();
        }

        private void Update()
        {
            if (isTimeRunning && timeRemaining.Value > 0)
            {
                timeRemaining.Value -= Time.deltaTime;
                DisplayTimer(timeRemaining.Value);
            }
            else StopTimer();
        }

        private void DisplayTimer(float timerRemaining)
        {
            var time = TimeSpan.FromSeconds(timerRemaining);
            text.text = time.ToString("mm':'ss");
        }
    }
}