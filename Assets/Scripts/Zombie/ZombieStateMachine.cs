using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    public State currentState { get; private set; }
    protected Dictionary<ZombieStateType, State> states = new Dictionary<ZombieStateType, State>();
    private bool isRunning;

    public void Initialize(ZombieStateType startingState)
    {
        if (states.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
    }
    public void AddState(ZombieStateType stateName, State state)
    {
        if (states.ContainsKey(stateName)) return;
        states.Add(stateName, state);
    }
    public void RemoveState(ZombieStateType stateName)
    {
        if (!states.ContainsKey(stateName)) return;
        states.Remove(stateName);
    }
    public void ChangeState(ZombieStateType stateName)
    {
        Debug.Log("state name is now: " + stateName.ToString());

        if (isRunning)
        {
            StopRunningState();
        }
        if (!states.ContainsKey(stateName)) return;

        currentState = states[stateName];
        currentState._Start();

        if (currentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0, currentState.UpdateInterval);
        }
        isRunning = true;

    }
    void StopRunningState()
    {
        isRunning = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));

    }
    private void IntervalUpdate()
    {
        if (isRunning)
        {
            currentState.IntervalUpdate();
        }
    }
    public void Update()
    {
        if (isRunning)
        {
            currentState._Update();
        }
    }
}
