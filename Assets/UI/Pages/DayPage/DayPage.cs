using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DayPage : MonoBehaviour
{
    public UIDocument document;
    public Button nextbutton;
    public Label timerLabel;
    public Button addTimeButton;

    private float remainedTime = 0;

    public delegate void OnConversationEndEvent();
    public event OnConversationEndEvent OnConversationEnd;

    void Start()
    {
        document = GetComponent<UIDocument>();
        nextbutton = document.rootVisualElement.Q<Button>("next-button");
        timerLabel = document.rootVisualElement.Q<Label>("timer-label");
        addTimeButton = document.rootVisualElement.Q<Button>("add-time-button");


        addTimeButton.clicked += AddTime;
    }

    void Update()
    {
        if (remainedTime > 0)
        {
            remainedTime -= Time.deltaTime;
            if (remainedTime <= 0 ) {
                EndArgument();
            } else
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(remainedTime);
                string timeText = string.Format("{0:D2}:{1:D2}",  timeSpan.Minutes, timeSpan.Seconds);
                timerLabel.text = timeText;
            }
        }
    }

    public void StartTimer(float time = 120)
    {
        remainedTime = time;
    }

    public void AddTime()
    {
        remainedTime += 60;
    }

    public void EndArgument()
    {
        remainedTime = 0;
        OnConversationEnd?.Invoke();
    }
}
