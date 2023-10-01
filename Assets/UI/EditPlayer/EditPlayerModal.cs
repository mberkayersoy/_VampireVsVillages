using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EditPlayerModal : VisualElement

{
    public new class UxmlFactory : UxmlFactory<EditPlayerModal> { }

    // Components
    protected VisualElement ImageField;
    protected TextField NameField;
    public Button Save;

    public PlayerData _player;
    public PlayerData player
    {
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

    public bool show
    {
        get
        {
            return this.style.display != DisplayStyle.None;
        }
        set
        {
            this.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }

    public EditPlayerModal()
    {
        // Set UXML tree
        VisualTreeAsset asset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/EditPlayer/EditPlayer.uxml");
        asset.CloneTree(this);

        // Components
        ImageField = this.Q<VisualElement>("image");
        NameField = this.Q<TextField>("name");
        Save = this.Q<Button>("save-button");

        // Inline Style for Full page
        this.style.position = Position.Absolute;
        this.style.top = 0;
        this.style.left = 0;
        this.style.bottom = 0;
        this.style.right = 0;

        NameField.RegisterValueChangedCallback((ChangeEvent<string> v) => { _player.Name = v.newValue; UpdateFields(); });
    }

    public void SetPlayer(PlayerData p)
    {
        player = p;
    }

    protected void UpdateFields()
    {
        NameField.value = _player.Name;
    }

    public string GetPlayer()
    {
        return player.Name;
    }
}
