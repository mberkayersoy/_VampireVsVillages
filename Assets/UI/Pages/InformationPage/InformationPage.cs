using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class InformationPage : MonoBehaviour
{
    [HideInInspector]
    public UIDocument document;
    Label infoLabel;
    Button nextButton;

    public event EventHandler OnNextAction;

    void Start()
    {
        document = GetComponent<UIDocument>();
        infoLabel = document.rootVisualElement.Q<Label>("info");
        nextButton = document.rootVisualElement.Q<Button>("skip-button");

        nextButton.clicked += Next;
    }

    public void SetInfo(Player deadPlayer = null)
    {
        if (deadPlayer != null)
        {
            infoLabel.text = deadPlayer.PlayerData.Name + " is dead.";
            Debug.Log("SETINFO: " + deadPlayer.PlayerData.Name + " IS DEAD") ;
        }
        else
        {
            infoLabel.text = "No one died.";
            Debug.Log("SETINFO: NO ONE DIED");
        }

    }

    public void Next()
    {
        gameObject.GetComponentInParent<Router>().path = RouterPaths.Day;
        OnNextAction?.Invoke(this, EventArgs.Empty);
    }
}
