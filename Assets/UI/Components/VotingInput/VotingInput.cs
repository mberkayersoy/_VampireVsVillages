using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.CanvasScaler;

public class VotingInput : VisualElement
{
    public new class UxmlFactory : UxmlFactory<VotingInput> { }

    public VotingInput() { Init(); }
    public List<VoteData> votes;

    // Events
    public delegate void OnChangeEvent(Player player);
    public event OnChangeEvent OnChange;

    public VotingInput(List<VoteData> p) {
        Init();
        SetPlayers(p);
    }

    public void Init()
    {
        StyleSheet stylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/utils.uss");
        this.styleSheets.Add(stylesheet);
        this.AddToClassList("voting-input");
    }

    public void SetPlayers(List<VoteData> v, Player selected = null)
    {
        votes = v;

        this.Clear();
        foreach (VoteData vote in votes)
        {
            VoteAvatar avatar = new VoteAvatar(vote.player);
            avatar.clicked += (object sender, ClickEvent e) =>
            {
                OnSelectPlayer(vote.player);
            };

            if (vote.player == selected)
            {
                avatar.SetIsSelected(true);
            }

            avatar.SetVoteCount(vote.count);

            this.Add(avatar);
        }
    }

    public void OnSelectPlayer(Player player)
    {
        OnChange?.Invoke(player);
    }
}
