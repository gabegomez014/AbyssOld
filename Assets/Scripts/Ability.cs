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
    public Transform spawn;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility(int abilityIndex);
}