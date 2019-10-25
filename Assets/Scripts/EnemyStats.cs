using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 10;

    [HideInInspector] public int currentHealth { get; private set; }
    public CharacterStat attackPower;
    public CharacterStat speed;
    public CharacterStat defense;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamange(int damage)
    {
        print("Health before damage: " + currentHealth + " and the damage is " + damage);
        currentHealth -= damage;
        print("Current Health is: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("Enemy Died");
    }
}
