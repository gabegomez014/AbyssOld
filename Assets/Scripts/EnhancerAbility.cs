using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/EnhancerAbility")]
public class EnhancerAbility : Ability
{
    public string stat;
    [Range(0, 100)]
    public float effect;
    public Material enhancerMaterial;

    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {

        caster = obj.GetComponent<AbilityCaster>();
        this.aStat = stat;
        this.aEffect = effect;
        this.aEnhanceMaterial = enhancerMaterial;

    }

    public override void TriggerAbility(int abilityIndex)
    {
        caster.TriggerAbility(this);
    }
}
