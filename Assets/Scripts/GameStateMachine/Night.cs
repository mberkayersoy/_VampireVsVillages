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

        index = -1;
        Next(null);
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
        if (index < game.playerList.Count - 1)
        {
            index += 1;
            currentPlayer = game.playerList[index];

            if (currentPlayer.Role.RoleType == Roles.Vampire)
                nightPage.RenderPlayerVote(currentPlayer, game.playerList);
            else
                nightPage.RenderNoActivity(currentPlayer);

            return;
        }

        // On night activites end
        game.SetState(game.dayState);
    }
}
