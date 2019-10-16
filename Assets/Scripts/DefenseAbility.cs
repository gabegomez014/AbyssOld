using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DefenseAbility")]
public class DefenseAbility : Ability
{
    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {

        caster = obj.GetComponent<AbilityCaster>();
        caster.AddAbility(this);

    }

    public override void TriggerAbility(int abilityIndex)
    {
        caster.TriggerAbility(abilityIndex);
    }
}
