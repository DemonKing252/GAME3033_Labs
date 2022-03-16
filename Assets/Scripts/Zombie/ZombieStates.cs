using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStates : State
{

    [System.NonSerialized] public int movementZhash = Animator.StringToHash("Speed");
    [System.NonSerialized] public int isAttackingHash = Animator.StringToHash("IsAttacking");
    [System.NonSerialized] public int isDeadHash = Animator.StringToHash("IsDead");

    // Start is called before the first frame update
    protected ZombieComponent ownerZombie;

    public ZombieStates(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(stateMachine)
    {
        ownerZombie = zombie;
    }
}
[System.Serializable]
public enum ZombieStateType
{
    Idling,
    Attacking,
    Following,
    Dying
}
