using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability
{

    public float projectileForce = 500f;               // The force that projectile is sent flying at
    public float culminationTime = 1f;              // How long it takes the power to charge up

    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {

        caster = obj.GetComponent<AbilityCaster>();
        this.aCulminationTime = culminationTime;
        this.aProjectileForce = projectileForce;
        
    }

    public override void TriggerAbility(int abilityIndex)
    {
        caster.TriggerAbility(this);
    }

}
