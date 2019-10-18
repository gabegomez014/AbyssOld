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

    [HideInInspector] public MeshRenderer characterSkin;
    private AbilityCaster caster;

    public override void Initialize(GameObject obj)
    {

        caster = obj.GetComponent<AbilityCaster>();
        characterSkin = obj.GetComponent<MeshRenderer>();

        this.aCharacterSkin = characterSkin;
        this.aStat = stat;
        this.aEffect = effect;
        this.aEnhanceMaterial = enhancerMaterial;

    }

    public override void TriggerAbility()
    {
        caster.TriggerAbility(this);
    }
}
