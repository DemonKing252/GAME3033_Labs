using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    public ZombieDeadState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {

        // Set damageable objects here add later

    }
    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
    }

    public override void _Start()
    {
        base._Start();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZhash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadHash, true);
    }

    public override void _Update()
    {
    }
    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isDeadHash, false);
    }
}
