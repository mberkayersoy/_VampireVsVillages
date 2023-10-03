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
    public List<Player> players;

    // Events
    public delegate void OnChangeEvent(Player player);
    public event OnChangeEvent OnChange;

    public VotingInput(List<Player> p) {
        Init();
        SetPlayers(p);
    }

    public void Init()
    {
        StyleSheet stylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/utils.uss");
        this.styleSheets.Add(stylesheet);
        this.AddToClassList("voting-input");
    }

    public void SetPlayers(List<Player> p, Player selected = null)
    {
        players = p;

        this.Clear();
        foreach (Player player in players)
        {
            VoteAvatar avatar = new VoteAvatar(player);
            avatar.clicked += (object sender, ClickEvent e) =>
            {
                OnSelectPlayer(player);
            };

            if (player == selected)
            {
                avatar.SetIsSelected(true);
            }

            this.Add(avatar);
        }
    }

    public void OnSelectPlayer(Player player)
    {
        OnChange?.Invoke(player);
    }
}
