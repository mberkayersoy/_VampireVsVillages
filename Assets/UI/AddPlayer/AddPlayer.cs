using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class AddPlayer : MonoBehaviour
{
    UIDocument document;
    VisualElement container;
    Button addPlayerButton;
    Button nextButton;

    EditPlayerModal editModal;

    public event EventHandler OnPlayerAdded;
    public event EventHandler OnPlayerUpdated;

    void Start()
    {
        document = GetComponent<UIDocument>();
        container = document.rootVisualElement.Q<VisualElement>("players-container");
        addPlayerButton = document.rootVisualElement.Q<Button>("add-player-button");
        nextButton = document.rootVisualElement.Q<Button>("next-button");


        // Add Modal
        editModal = new EditPlayerModal();
        document.rootVisualElement.Add(editModal);
        editModal.show = false;
        editModal.Save.clicked += onSavePlayer;


        addPlayerButton.clicked += () =>
        {
            if (OnPlayerAdded != null) OnPlayerAdded?.Invoke(this, null);
        };

        nextButton.clicked += () =>
        {
            gameObject.GetComponentInParent<Router>().path = RouterPaths.Roles;
        };

        this.OnPlayerAdded += (object sender, EventArgs a) =>
        {
            GameManager.Instance.AddNewPlayer();
            RenderPlayers();
        };

        this.OnPlayerUpdated += (object sender, EventArgs a) =>
        {
            RenderPlayers();
        };
    }

    public void OnEditPLayer(PlayerData player)
    {
        editModal.SetPlayer(player);
        editModal.show = true;
    }

    public void onSavePlayer()
    {
        if (OnPlayerUpdated != null) OnPlayerUpdated?.Invoke(this, null);
        editModal.show = false;
    }

    public void RenderPlayers()
    {
        List<PlayerData> players = GameManager.Instance.playersDataList;

        container.Clear();

        for (int i = 0; i < players.Count; i++)
        {
            PlayerAvatar b = new PlayerAvatar();
            b.player = players[i];
            b.clicked += (object sender, ClickEvent e) =>
            {
                OnEditPLayer(((PlayerAvatar)sender).player);
            };
            container.Add(b);
        }
    }

}
