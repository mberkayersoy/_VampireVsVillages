using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Player> playerList;


    // STATES
    public State currentState;
    public Start startState;
    public Day dayState;
    public Night nightState;
    public Vote voteState;
    public End endState;

    private void Start()
    {
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
