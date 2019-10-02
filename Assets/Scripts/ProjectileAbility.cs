using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability
{

    public float particleForce = 500f;

    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {

        caster = obj.GetComponent<AbilityCaster>();
        caster.AddAbility(this);
        caster.particleForce = particleForce;
        
    }

    public override void TriggerAbility(int abilityIndex)
    {
        caster.TriggerAbility(abilityIndex);
    }

}
