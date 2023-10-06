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

    private Player currentPlayer;
    private Player selectedPlayer;
    private List<VoteData> votes;

    public delegate void OnChooseEvent(Player player);
    public event OnChooseEvent OnChoose;

    void Start()
    {
        document = GetComponent<UIDocument>();
        voteContainer = document.rootVisualElement.Q<VisualElement>("vote-container");
        chooseButton = document.rootVisualElement.Q<Button>("choose-button");

        input = new VotingInput();
        input.OnChange += (Player player) =>
        {
            selectedPlayer = player;
            input.SetPlayers(votes, selectedPlayer);
        };

        voteContainer.Add(input);

        chooseButton.clicked += OnSelectionEnd;

        selectedPlayer = null;

    }

     public void RenderPlayerVote(Player p, List<VoteData> v)
    {
        votes = v;
        currentPlayer = p;
        selectedPlayer = null;

        input.SetPlayers(votes);
    }


    public void OnSelectionEnd()
    {
        OnChoose.Invoke(selectedPlayer);
        selectedPlayer = null;
    }
}
