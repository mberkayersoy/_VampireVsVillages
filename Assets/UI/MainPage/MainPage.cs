using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class MainPage : MonoBehaviour
{
    [HideInInspector]
    public UIDocument document;
    [HideInInspector]
    public Button newGame;

    // Start is called before the first frame update
    void Start()
    {
        document = GetComponent<UIDocument>();
        newGame = document.rootVisualElement.Q<Button>("new-game-button");
    }
}
