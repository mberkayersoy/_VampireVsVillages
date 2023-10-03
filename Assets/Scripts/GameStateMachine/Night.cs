using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : State
{

    NightPage nightPage;
    Player currentPlayer;
    int index = 0;

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

    public override void OnExit()
    {
        base.OnExit();
        nightPage.OnChoose -= Next;
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
        game.SetState(game.dayState);
    }

    public void RenderAbilityPage(int i)
    {
        index = i;
        currentPlayer = game.playerList[index];

        if (currentPlayer.Role.RoleType == Roles.Vampire)
            nightPage.RenderPlayerVote(currentPlayer, game.playerList);
        else
            nightPage.RenderNoActivity(currentPlayer);
    }
}
