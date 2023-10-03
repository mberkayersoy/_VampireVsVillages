using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DayPage : MonoBehaviour
{
    public UIDocument document;
    public Button nextbutton;

    void Start()
    {
        document = GetComponent<UIDocument>();
        nextbutton = document.rootVisualElement.Q<Button>("next-button");
    }
}
