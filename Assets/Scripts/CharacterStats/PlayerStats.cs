using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image healthBarImg;
    [SerializeField]
    private Image areteBarImg;
    [HideInInspector] public CharacterStat attackPower;
    [HideInInspector] public CharacterStat attackSpeed;
    [HideInInspector] public CharacterStat speed;
    [HideInInspector] public CharacterStat defense;
    [HideInInspector] public CharacterStat currentHealth { get; private set; }
    [HideInInspector] public CharacterStat currentArete { get; private set; }

    private PlayerInfo playerInfo;

    private void Awake()
    {
        LoadInfo();
    }


    public void TakeDamange(int damage)
    {
        currentHealth.baseValue -= damage;
        float currentPct = currentHealth.Value / playerInfo.health;
        healthBarImg.fillAmount = currentPct;   // For a smoother animation, Lerp this value in a co-routine. Not necessary right now.
    }

    public void UseArete(int usage)
    {
        currentArete.baseValue -= usage;
        float currentPct = currentArete.Value / playerInfo.arete;
        areteBarImg.fillAmount = currentPct;   // For a smoother animation, Lerp this value in a co-routine. Not necessary right now.
    }

    public float GetSpeed()
    {
        return speed.Value;
    }

    public float GetPower()
    {
        return attackPower.Value;
    }

    private void Die()
    {
        print("Player Died");
    }

    private void LoadInfo()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.abyss"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.abyss", FileMode.Open);
            playerInfo = (PlayerInfo)bf.Deserialize(file);
            file.Close();

            attackPower = new CharacterStat(playerInfo.power);
            attackSpeed = new CharacterStat(playerInfo.atkSpd);
            defense = new CharacterStat(playerInfo.defense);
            speed = new CharacterStat(playerInfo.speed);
            currentHealth = new CharacterStat(playerInfo.health);
            currentArete = new CharacterStat(playerInfo.arete);

        }
    }
}
