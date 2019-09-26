using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Abilities/RaycastAbility")]
public class RaycastAbility : Ability
{
    public int damage = 1;
    public float range = 50f;
    public float force = 100f;
    public GameObject abilityParticles;

    private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        rcShoot = obj.GetComponent<RaycastShootTriggerable>();
        rcShoot.Initialize();

        rcShoot.damage = 1;
        rcShoot.range = range;
        rcShoot.force = force;
    }

    public override void TriggerAbility()
    {
        rcShoot.Fire();
    }
}
