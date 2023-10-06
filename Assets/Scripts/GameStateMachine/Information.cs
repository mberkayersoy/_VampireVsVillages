using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : State
{
    InformationPage informationPage;
    public Information(Game sm) : base(sm)
    {
        informationPage = UIManager.Instance.informationPage;
        game.nightState.OnPlayerDeadAction += NightState_OnPlayerDeadAction;

    }
    public override void OnEnter()
    {
        UIManager.Instance.router.path = RouterPaths.Information;
        //UIManager.Instance.startPage.nextbutton.clicked += Next;
        informationPage.OnNextAction += InformationPage_OnNextAction;
    }

    private void InformationPage_OnNextAction(object sender, System.EventArgs e)
    {
        Debug.Log("Information previousState: " + game.previousState);
        if (game.previousState == game.nightState)
        {
            game.SetState(game.dayState);
        }
        else if (game.previousState == game.voteState)
        {
            game.SetState(game.nightState);
        }

        Debug.Log("Information to nextState: " + game.currentState);
    }

    private void NightState_OnPlayerDeadAction(object sender, Night.OnPlayerDeadActionEventArgs e)
    {
        informationPage.SetInfo(e.deadPlayer);
    }
    //public void Next()
    //{
    //    Debug.Log("Information Next: " + game.previousState);
    //    if (game.previousState == game.nightState)
    //    {
    //        game.SetState(game.dayState);
    //    }
    //    else if (game.previousState == game.voteState)
    //    {
    //        game.SetState(game.nightState);
    //    }
    //}

    public override void OnExit()
    {
        game.nightState.OnPlayerDeadAction -= NightState_OnPlayerDeadAction;
        informationPage.OnNextAction -= InformationPage_OnNextAction;
        base.OnExit();
    }

}
