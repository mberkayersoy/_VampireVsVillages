using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NightPage : MonoBehaviour
{
    UIDocument document;
    VisualElement voteContainer;
    VisualElement hideRoleContainer;
    VisualElement showRoleContainer;
    Button chooseButton;

    RolesAvatar roleAvatar;
    VotingInput input;

    public Player selectedPlayer;

    public delegate void OnChooseEvent(Player player);
    public event OnChooseEvent OnChoose;

    void Start()
    {
        document = GetComponent<UIDocument>();
        voteContainer = document.rootVisualElement.Q<VisualElement>("vote-container");
        showRoleContainer = document.rootVisualElement.Q<VisualElement>("show-role-container");
        hideRoleContainer = document.rootVisualElement.Q<VisualElement>("hide-role-container");
        chooseButton = document.rootVisualElement.Q<Button>("choose-button");

        input = new VotingInput();
        voteContainer.Add(input);

        chooseButton.clicked += OnSelectionEnd;

        hideRoleContainer.RegisterCallback<ClickEvent>(OnShowRole);
    }

    public void RenderPlayerVote(Player p, List<Player> players)
    {
        hideRoleContainer.style.display = DisplayStyle.Flex;
        input.style.display = DisplayStyle.Flex;
        selectedPlayer = null;

        SetRole(p.Role.RoleType);

        input.SetPlayers(players);
        input.OnChange += (Player player) =>
        {
            selectedPlayer = player;
            input.SetPlayers(players, selectedPlayer);
        };
    }

    public void RenderNoActivity(Player p)
    {
        hideRoleContainer.style.display = DisplayStyle.Flex;
        input.style.display = DisplayStyle.None;
        selectedPlayer = null;

        SetRole(p.Role.RoleType);

    }

    public void OnShowRole(ClickEvent e)
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
