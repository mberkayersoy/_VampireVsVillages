using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NightPage : MonoBehaviour
{
    UIDocument document;
    VisualElement voteContainer;
    VisualElement hideRoleContainer;
    VisualElement showRoleContainer;
    Button chooseButton;
    Button showRoleButton;
    Label nextPlayerNameLabel;
    RolesAvatar roleAvatar;
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
        showRoleContainer = document.rootVisualElement.Q<VisualElement>("show-role-container");
        hideRoleContainer = document.rootVisualElement.Q<VisualElement>("hide-role-container");
        chooseButton = document.rootVisualElement.Q<Button>("choose-button");
        showRoleButton = document.rootVisualElement.Q<Button>("show-role-button");
        nextPlayerNameLabel = hideRoleContainer.Q<Label>("next-player-label");
        input = new VotingInput();
        voteContainer.Add(input);

        chooseButton.clicked += OnSelectionEnd;
        showRoleButton.clicked += ShowRoleButton_clicked;

        input.OnChange += (Player player) =>
        {
            selectedPlayer = player;
            input.SetPlayers(votes, selectedPlayer);
        };

    }

    public void RenderPlayerVote(Player p, List<Player> players)
    {
        hideRoleContainer.style.display = DisplayStyle.Flex;
        input.style.display = DisplayStyle.Flex;
        nextPlayerNameLabel.text = p.PlayerData.Name;
        currentPlayer = p;
        selectedPlayer = null;

        SetRole(p.Role.RoleType);

        votes = new List<VoteData>(players.Select(player => new VoteData(player)));
        input.SetPlayers(votes);
      
    }

    public void RenderNoActivity(Player p)
    {
        nextPlayerNameLabel.text = p.PlayerData.Name;
        hideRoleContainer.style.display = DisplayStyle.Flex;
        input.style.display = DisplayStyle.None;
        selectedPlayer = null;


        SetRole(p.Role.RoleType);
        currentPlayer = p;
    }

    public void OnShowRole(ClickEvent e)
    {
        hideRoleContainer.style.display = DisplayStyle.None;
    }

    private void ShowRoleButton_clicked()
    {
        hideRoleContainer.style.display = DisplayStyle.None;
    }
    public void SetRole(Roles r)
    {
        showRoleContainer.Clear();
        roleAvatar = new RolesAvatar(r);
        showRoleContainer.Add(roleAvatar);
    }

    public void OnSelectionEnd()
    {
        OnChoose.Invoke(selectedPlayer);
    }
}
