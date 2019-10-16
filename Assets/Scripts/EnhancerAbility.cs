using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/EnhancerAbility")]
public class EnhancerAbility : Ability
{
    public string stat;
    [Range(0, 100)]
    public float effect;

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
