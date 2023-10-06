using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : State
{
    NightPage nightPage;
    Player currentPlayer;
    int index = 0;
    public event EventHandler<OnPlayerDeadActionEventArgs> OnPlayerDeadAction;
    public class OnPlayerDeadActionEventArgs : EventArgs
    {
        public Player deadPlayer;
    }

    public Night(Game sm) : base(sm)
    {
        nightPage = UIManager.Instance.nightPage;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        UIManager.Instance.router.path = RouterPaths.Night;

        RenderAbilityPage(0);
        nightPage.OnChoose += Next;
    }

    public void Next(Player p)
    {
        // TODO: Night activites...
        // Apply Ability
        if (p != null)
        {
            currentPlayer.Role.Ability(p);
        }

        // Move to next player
        if (index < game.playerList.Count - 1)
        {
            RenderAbilityPage(index + 1);
            return;
        }

        // On night activites end
        //game.SetState(game.dayState);
        game.SetState(game.informationState);
    }

    public void RenderAbilityPage(int i)
    {
        index = i;
        currentPlayer = game.playerList[index];

        if (currentPlayer.Role.RoleType != Roles.Villager)
            nightPage.RenderPlayerVote(currentPlayer, currentPlayer.Role.GetAccessiblePlayers(game.playerList));
        else
            nightPage.RenderNoActivity(currentPlayer);
    }

    public override void OnExit()
    {
        bool isPlayerDead = false;
        foreach (Player player in game.playerList)
        {
            if (player.CheckIsDead())
            {
                OnPlayerDeadAction?.Invoke(this, new OnPlayerDeadActionEventArgs
                {
                    deadPlayer = player
                });
                isPlayerDead = true;
            }
        }
        if (!isPlayerDead)
        {
            OnPlayerDeadAction?.Invoke(this, new OnPlayerDeadActionEventArgs
            {
                deadPlayer = null
            });
        }


        nightPage.OnChoose -= Next;
    }
}
