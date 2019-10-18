using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DefenseAbility")]
public class DefenseAbility : Ability
{
    private AbilityCaster caster;
    public float radius = 1;

    public override void Initialize(GameObject obj)
    {
        caster = obj.GetComponent<AbilityCaster>();
        this.aRadius = radius;
    }

    public override void TriggerAbility()
    {
        caster.TriggerAbility(this);
    }
}
