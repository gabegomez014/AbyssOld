using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth { get; private set; }

    public CharacterStat attackPower;
    public CharacterStat attackSpeed;
    public CharacterStat movement;

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
        print("Player Died");
    }
}
