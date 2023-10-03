using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VotePage : MonoBehaviour
{
    UIDocument document;
    VisualElement voteContainer;
    Button chooseButton;
    VotingInput input;

    public Player selectedPlayer;

    public delegate void OnChooseEvent(Player player);
    public event OnChooseEvent OnChoose;

    void Start()
    {
        document = GetComponent<UIDocument>();
        voteContainer = document.rootVisualElement.Q<VisualElement>("vote-container");
        chooseButton = document.rootVisualElement.Q<Button>("choose-button");

        input = new VotingInput();
        voteContainer.Add(input);

        chooseButton.clicked += OnSelectionEnd;
    }

    public void RenderPlayerVote(List<Player> players)
    {
        selectedPlayer = null;

        input.SetPlayers(players);
        input.OnChange += (Player player) =>
        {
            selectedPlayer = player;
            input.SetPlayers(players, selectedPlayer);
        };
    }

    public void OnSelectionEnd()
    {
        OnChoose.Invoke(selectedPlayer);
    }
}
