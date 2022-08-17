using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Text timerText;
    [SerializeField] private Text objectCount;
    [SerializeField] private Text levelText;

    public Text TimerText { get { return timerText; } }
    public Text ObjectCount { get { return objectCount; } }
    public Text LevelText { get { return levelText; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
}
