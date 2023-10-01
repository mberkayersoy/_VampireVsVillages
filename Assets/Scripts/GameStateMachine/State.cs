using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Game game;

    public State(Game sm)
    {
        game = sm;
    }
    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
}
