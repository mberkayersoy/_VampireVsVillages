using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VoteAvatar : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VoteAvatar> { }

    public VoteAvatar() { Init(); }

    private Player player;
    private int vote = 0;
    private bool isSelected;

    private PlayerAvatar playerAvatar;
    public Label voteLabel;

    public event EventHandler<ClickEvent> clicked
    {
        add { playerAvatar.clicked += value; }
        remove { playerAvatar.clicked -= value; }
    }

    public VoteAvatar(Player p)
    {
        Init();
        SetPlayer(p);
    }

    public void Init()
    {
        this.AddToClassList("avatar-container");
        playerAvatar = new PlayerAvatar();
        playerAvatar.ImageField.AddToClassList("avatar-image");
        voteLabel = new Label();
        voteLabel.style.flexGrow = 0;

        this.Add(playerAvatar);
        this.playerAvatar.Add(voteLabel);
    }

    public void SetPlayer(Player p)
    {
        player = p;
        playerAvatar.player = player.PlayerData;
    }

    public void SetVoteCount(int v)
    {
        vote = v;
        if (v > 0)
        {
            voteLabel.text = vote.ToString();
        }
        else
        {
            voteLabel.text = "";
        }

    }

    public void SetIsSelected(bool s)
    {
        isSelected = s;
        if (isSelected)
        {
            this.AddToClassList("selected-avatar");
        }
        else
        {
            this.RemoveFromClassList("selected-avatar");
        }
    }

}
