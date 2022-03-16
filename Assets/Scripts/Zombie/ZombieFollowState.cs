using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowState : ZombieStates
{
    GameObject followTarget;
    float stoppingDist = 2f;
    public ZombieFollowState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;
        UpdateInterval = 2f;
        // Set damageable objects here add later
    }

    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        ownerZombie.zombieNavMeshAgent.SetDestination(followTarget.transform.position);
    }

    public override void _Start()
    {
        base._Start();

        ownerZombie.zombieNavMeshAgent.SetDestination(followTarget.transform.position);
        //ownerZombie.zombieNavMeshAgent.isStopped = false;
        //ownerZombie.zombieNavMeshAgent.ResetPath();
        //ownerZombie.zombieAnimator.SetFloat(movementZhash, 1f);
        //ownerZombie.zombieAnimator.SetBool(isAttackingHash, false);
    }

    public override void _Update()
    {
        base._Update();

        float moveZ = ownerZombie.zombieNavMeshAgent.velocity.normalized.z != 0 ? 1f : 0f;
        ownerZombie.zombieAnimator.SetFloat(movementZhash, moveZ);

        ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);

        float dist = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);

        if (dist < stoppingDist)
        {
            // Change state to following
            stateMachine.ChangeState(ZombieStateType.Attacking);
        }

    }
    public override void Exit()
    {
        base.Exit();
        //ownerZombie.zombieNavMeshAgent.isStopped = false;
    }
}
