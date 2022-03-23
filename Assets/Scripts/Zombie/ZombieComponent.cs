using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public int zombieDamage = 5;
    public NavMeshAgent zombieNavMeshAgent;
    public Animator zombieAnimator;
    public ZombieStateMachine zombieStateMachine;
    public GameObject followTarget;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Awake()
    {
        zombieNavMeshAgent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponent<Animator>();
        zombieStateMachine = GetComponent<ZombieStateMachine>();
        
    }
    private void Start()
    {
        followTarget = FindObjectOfType<PlayerController>().gameObject;
        Initialize(followTarget);

    }
    public void Initialize(GameObject _followTarget)
    {


        //followTarget = _followTarget;
        ZombieIdleState idleState = new ZombieIdleState(null, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Idling, idleState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Attacking, attackState);

        ZombieFollowState followState = new ZombieFollowState(followTarget, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Following, followState);

        ZombieDeadState deadState = new ZombieDeadState(null, this, zombieStateMachine);
        zombieStateMachine.AddState(ZombieStateType.Dying, deadState);

        zombieStateMachine.ChangeState(ZombieStateType.Following);
    }
    public void OnAttackNotify()
    {
        ///GetComponent<NavMeshAgent>().isStopped = true;
        if (pController != null)
        {
            pController.Health -= 10f;
        }
    }
    private PlayerController pController = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pController = other.GetComponent<PlayerController>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pController = null;
        }
    }

}
