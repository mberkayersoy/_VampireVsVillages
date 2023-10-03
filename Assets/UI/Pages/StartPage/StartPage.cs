using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartPage : MonoBehaviour
{
    public UIDocument document;
    public Button nextbutton;

    // Start is called before the first frame update
    void Start()
    {
        nextbutton = document.rootVisualElement.Q<Button>("next-button");
    }
}
