using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    protected ZombieStateMachine stateMachine;
    public float UpdateInterval { get; protected set; } = 1f;
    
    protected State(ZombieStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void _Start()
    {

    }
    public virtual void IntervalUpdate()
    {

    }
    public virtual void _Update()
    {

    }
    public virtual void Exit()
    {

    }
}
