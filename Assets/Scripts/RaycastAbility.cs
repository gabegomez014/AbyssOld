using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Abilities/RaycastAbility")]
public class RaycastAbility : Ability
{
    public int damage = 1;
    public float range = 50f;
    public float force = 100f;

    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {
        caster = obj.GetComponent<AbilityCaster>();
        this.aDamage = damage;
        this.aRange = range;
        this.aRCForce = force;
    }

    public override void TriggerAbility(int abilityIndex)
    {
        caster.TriggerAbility(this);
    }
}
