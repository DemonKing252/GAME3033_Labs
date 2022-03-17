using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : ZombieStates
{
    GameObject followTarget;
    float attackRange = 2.5f;

    public ZombieAttackState(GameObject _followTarget, ZombieComponent zombie, ZombieStateMachine stateMachine) : base(zombie, stateMachine)
    {
        followTarget = _followTarget;

        // Set damageable objects here add later

    }



    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
    }

    public override void _Start()
    {
        base._Start();

        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZhash, 0);
        ownerZombie.zombieAnimator.SetBool(isAttackingHash, true);
    }
    public override void _Update()
    {

        //ownerZombie.zombieAnimator.SetBool(isAttackingHash, true);
        //base.Update();
        ownerZombie.transform.LookAt(followTarget.transform.position, Vector3.up);


        float dist = Vector3.Distance(ownerZombie.transform.position, followTarget.transform.position);

        if (dist > attackRange)
        {
            stateMachine.ChangeState(ZombieStateType.Following);
        }

    }

    public void StopAttacking()
    {
        ownerZombie.zombieNavMeshAgent.isStopped = false;
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieAnimator.SetBool(isAttackingHash, false);
        //ownerZombie.zombieAnimator.SetFloat(movementZhash, 1);
    }
}
