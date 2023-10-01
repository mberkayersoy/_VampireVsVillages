using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VoteAvatar : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VoteAvatar> { }

    public VoteAvatar() { }

    private Player player;
    private int vote = 0;
    private bool isSelected;

    private PlayerAvatar playerAvatar;
    public Label voteLabel;

    public event EventHandler<ClickEvent> clicked {
        add { playerAvatar.clicked += value; }
        remove { playerAvatar.clicked -= value; }
    }

    public VoteAvatar(Player p)
    {
        playerAvatar = new PlayerAvatar();
        voteLabel = new Label();
        voteLabel.style.flexGrow = 0;

        this.Add(playerAvatar);
        this.playerAvatar.Add(voteLabel);

        SetPlayer(p);
    }

    public void SetPlayer(Player p)
    {
        player = p;
        playerAvatar.player = player.PlayerData;
    }

    public void SetVoteCount(int v)
    {
        vote = v;
        voteLabel.text = vote.ToString();
    }

    public void SetIsSelected(bool s)
    {
        isSelected = s;
        if (isSelected)
        {
            this.AddToClassList("selected-avatar");
        } else
        {
            this.RemoveFromClassList("selected-avatar");
        }
    }

}
