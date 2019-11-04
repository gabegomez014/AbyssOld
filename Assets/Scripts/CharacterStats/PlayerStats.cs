using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxArete = 100;

    public int currentHealth { get; private set; }
    public int currentArete { get; private set; }

    [HideInInspector] public CharacterStat attackPower;
    [HideInInspector] public CharacterStat attackSpeed;
    [HideInInspector] public CharacterStat speed;
    [HideInInspector] public CharacterStat defense;
    [HideInInspector] public CharacterStat arete; // Basically Magic Points

    private void Awake()
    {
        currentHealth = maxHealth;
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
