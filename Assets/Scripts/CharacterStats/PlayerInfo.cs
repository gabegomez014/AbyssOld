using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public bool newPlayer = true;
    public int khono = 10;
    public int power = 5;
    public int defense = 5;
    public int speed = 5;
    public int atkSpd = 5;

    public PlayerInfo Clone()
    {
        PlayerInfo clone = new PlayerInfo();

        clone.newPlayer = this.newPlayer;
        clone.power = this.power;
        clone.defense = this.defense;
        clone.speed = this.speed;
        clone.atkSpd = this.atkSpd;
        clone.khono = this.khono;

        return clone;
    }

    public bool Compare(PlayerInfo comparer)
    {
        if (comparer.khono == this.khono && comparer.power == this.power && comparer.defense == this.defense && comparer.speed == this.speed && comparer.atkSpd == this.atkSpd)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
