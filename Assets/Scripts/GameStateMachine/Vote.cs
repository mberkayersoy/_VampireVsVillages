using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vote : State
{
    VotePage page;

    public Vote(Game sm) : base(sm)
    {
        page = UIManager.Instance.votePage;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        UIManager.Instance.router.path = RouterPaths.Vote;
        page.OnChoose += Next;
    }

    public override void OnExit()
    {
        base.OnExit();
        page.OnChoose -= Next;
    }

    public void Next(Player p)
    {
        // TODO: voting activity 
        // TODO: is game end (?) -> to End State
        // TODO: is voting activity end -> to Night State
        game.SetState(game.nightState);
    }
}
