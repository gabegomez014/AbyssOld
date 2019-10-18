using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCaster : MonoBehaviour
{ 
    public Transform spawn;                            // Transform variable to hold the location where we will spawn our projectile
    public static int abilityCount = 9;                // Amount of abilities player can use at once

    private GameObject clonedParticle;
    private Ability selectedAbility;

    public void TriggerAbility(Ability triggeredAbility)
    {
        selectedAbility = triggeredAbility;
        StartCoroutine(CastAbility());
    }

    IEnumerator CastAbility()
    {
        var abilityType = selectedAbility.GetType().ToString();

        switch(abilityType)
        {
            case "ProjectileAbility":
                Culmination();
                yield return new WaitForSeconds(selectedAbility.aCulminationTime);
                Launch();
                yield return new WaitForSeconds(selectedAbility.aLifetime);
                Release();
                break;

            case "DefenseAbility":
                Defend();
                yield return new WaitForSeconds(selectedAbility.aLifetime);
                Release();
                break;

            case "EnhancerAbility":
                Enhance();
                break;

            case "RaycastAbility":
                print("We see the ability");
                break;
        }
        
    }

    // This represents the ability being charged up
    private void Culmination()
    {
        //Instantiate a copy of our projectile and store it in a new GameObject variable called clonedParticle
        clonedParticle = Instantiate(selectedAbility.aParticles, spawn.position, transform.rotation) as GameObject;
    }

    // This represents the ability being launched. This is mainly used for the projectile class of abilities
    private void Launch()
    {
        //Add force to the instantiated bullet, pushing it forward away from the spawn location, using projectile force for how hard to push it away
        clonedParticle.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * selectedAbility.aProjectileForce);
    }

    // This method represents the casting of a defense ability
    private void Defend()
    {
        clonedParticle = Instantiate(selectedAbility.aParticles, spawn.position, transform.rotation) as GameObject;
    }

    // This method represents the casting of an enchaner abiltiy
    private void Enhance()
    {
        selectedAbility.aCharacterSkin.materials[0] = selectedAbility.aEnhanceMaterial;
    }

    // This represents the death of the ability
    private void Release()
    {
        
        Destroy(clonedParticle);
    }
}
