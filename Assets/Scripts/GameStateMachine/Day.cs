using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        page.StartTimer(10);
        page.OnConversationEnd += Next;
    }

    public override void OnExit()
    {
        base.OnExit();
        page.OnConversationEnd -= Next;
    }

    public void Next()
    {
        game.SetState(game.voteState);
    }
}
