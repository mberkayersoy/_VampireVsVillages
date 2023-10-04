using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VoteData
{
    public int count = 0;
    public Player player;
    public VoteData(Player player)
    {
        this.player = player;
    }
}

public class Voter 
{
    public List<VoteData> votes;

    public Voter(List<Player> players)
    {
        votes = new List<VoteData>(players.Select(p => new VoteData(p)));
    }

    public void VoteFor(Player player)
    {
        VoteData vote = votes.Find(v => v.player == player);
        vote.count++;
    }

    public List<Player> GetResult()
    {
        int max = 0;
        List<Player> result = new List<Player>();
        foreach (VoteData vote in votes) {
            if (vote.count > max)
            {
                max = vote.count;
                result.Clear();
                result.Add(vote.player);
            } else if (vote.count == max && vote.count > 0) {
                result.Add(vote.player);
            }
        }
        return result;
    }

    public void Reset()
    {
        foreach (VoteData vote in votes) {
            vote.count = 0;
        }
    }
}
