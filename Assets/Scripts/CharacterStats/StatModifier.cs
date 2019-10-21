using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    Flat = 100,       // Simply add a constant to the stat
    PercentAdd = 200, // Stack ability by adding this modifier to the stack
    PercentMult = 300 // Stack ability by multiplying this modifier to the stack
}

public class StatModifier
{
    public readonly int order;
    public readonly float value;
    public readonly StatModType type;
    public readonly Ability ability; // Added this variable

    public StatModifier(float value, StatModType type, int order, Ability ability)
    {
        this.value = value;
        this.type = type;
        this.order = order;
        this.ability = ability;
    }

    // Deafult Constructor
    public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }

    // Requires Value, Type and Order. Sets Source to its default value: null
    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    // Requires Value, Type and Source. Sets Order to its default value: (int)Type
    public StatModifier(float value, StatModType type, Ability ability) : this(value, type, (int)type, ability) { }
}
