using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Vote : State
{
    readonly VotePage page;

    int index;
    Player currentPlayer;
    Voter voter;

    public Vote(Game sm) : base(sm)
    {
        page = UIManager.Instance.votePage;
        voter = new Voter(game.playerList);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        UIManager.Instance.router.path = RouterPaths.Vote;

        voter.Reset();

        RenderVoteForPlayer(0);
        page.OnChoose += Next;
    }

    public override void OnExit()
    {
        List<Player> result = voter.GetResult();
        if (result.Count > 1)
        {
            Debug.Log("Votes are equal nobody dies.");
        } else if (result.Count == 1)
        {
            Debug.Log(result[0].PlayerData.Name + " is died.");
            result[0].IsDead = true;
        } else
        {
            Debug.Log("Nobody died.");
        }

        base.OnExit();
        page.OnChoose -= Next;
    }

    public void Next(Player p)
    {
        // TODO: voting activity 
        // TODO: is game end (?) -> to End State
        // TODO: is voting activity end -> to Night State

        if (p != null)
        {
            voter.VoteFor(p);
        }
        else
        {
            Debug.Log("(Next) Player null: " + p);
        }

        if (index < game.playerList.Count - 1)
        {
            RenderVoteForPlayer(index + 1);
            return;
        }
        game.SetState(game.nightState);
    }

    public void RenderVoteForPlayer(int i)
    {
        index = i;
        currentPlayer = game.playerList[index];
        List<VoteData> list = new List<VoteData>(voter.votes.Where(vote => vote.player != currentPlayer && !vote.player.IsDead));
        page.RenderPlayerVote(currentPlayer, list);
    }
}
