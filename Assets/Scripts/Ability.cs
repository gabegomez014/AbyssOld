using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject
{

    public string aName = "New Ability";            // Name of ability
    public Sprite aSprite;                          // The sprite for the cooldown
    public AudioClip aSound;                        // The sound for the ability
    public float aBaseCoolDown = 1f;                // The ability's cooldown
    public float aLifetime = 1f;                     // How long the ability can live
    public GameObject aParticles;                   // The particle systems prefab for the ability
    public Transform spawn;                         // Where the particle will spawn * May have to be an array in the future *

    /* Projectile Ability */

    [HideInInspector] public float aProjectileForce;        
    [HideInInspector] public float aCulminationTime;
    
    /* Projectile Ability */

    /* Raycast Ability */

    [HideInInspector] public int aDamage;                 
    [HideInInspector] public float aRange;
    [HideInInspector] public float aRCForce;

    /* Raycast Ability */

    /* Enhancer Ability */

    [HideInInspector] public string aStat;
    [HideInInspector] public float aEffect;
    [HideInInspector] public Material aEnhanceMaterial;

    /* Enhancer Ability */

    /* Defense Ability */

    /* Defense Ability */

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility(int abilityIndex);
}