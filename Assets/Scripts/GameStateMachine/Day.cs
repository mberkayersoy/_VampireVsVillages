using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : State
{
    DayPage page;

    public Day(Game sm) : base(sm)
    {
        page = UIManager.Instance.dayPage;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        UIManager.Instance.router.path = RouterPaths.Day;
        page.nextbutton.clicked += Next;
    }

    public override void OnExit()
    {
        base.OnExit();
        page.nextbutton.clicked -= Next;
    }

    public void Next()
    {
        game.SetState(game.voteState);
    }
}
