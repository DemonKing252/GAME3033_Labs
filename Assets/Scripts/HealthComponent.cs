using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    public float CurrentHealth => currentHealth;

    [SerializeField]
    private float maxHealth;

    public float MaxHealth => maxHealth;
    private ZombieStateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<ZombieStateMachine>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        print("damage...");
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            stateMachine.ChangeState(ZombieStateType.Dying);
            Destroy(gameObject, 3f);
        }
    }

}
