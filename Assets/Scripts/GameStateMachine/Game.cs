using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public List<Player> playerList;


    // STATES
    public State currentState;
    public Start startState;
    public Day dayState;
    public Night nightState;
    public Vote voteState;
    public End endState;

    public Game()
    {
        startState = new(this);
        dayState = new(this); ;
        nightState = new(this);
        voteState = new(this);
        endState = new(this);

        SetState(startState);
    }

    public void SetState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
}
