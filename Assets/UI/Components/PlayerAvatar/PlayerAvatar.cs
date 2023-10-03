using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAvatar : VisualElement

{
    public new class UxmlFactory : UxmlFactory<PlayerAvatar> { }

    // Components
    protected VisualElement ImageField;
    protected Label NameField;

    // Data
    public PlayerData _player;
    public PlayerData player {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
            UpdateFields();
        }
    }

    // Events
    public event EventHandler<ClickEvent> clicked;


    public PlayerAvatar() {
        // Set UXML tree
        VisualTreeAsset asset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Components/PlayerAvatar/PlayerAvatar.uxml");
        asset.CloneTree(this);
        
        // Components
        ImageField = this.Q<VisualElement>("image");
        NameField = this.Q<Label>("name");

        // Events
        this.RegisterCallback<ClickEvent>(OnClick);
    }

    protected void UpdateFields()
    {
        NameField.text = _player.Name;
    }

    protected void OnClick(ClickEvent e)
    {
        if (clicked != null) clicked?.Invoke(this, e);
    }

}
