using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCaster : MonoBehaviour
{ 
    public Transform spawn;                            // Transform variable to hold the location where we will spawn our projectile
    public static int abilityCount = 9;                // Amount of abilities player can use at once
    [HideInInspector] public float particleForce = 250f;                    // Float variable to hold the amount of force which we will apply to launch our projectiles
    [HideInInspector] public float culminationTime = 1f;                    // How long the ability takes to charge up
    [HideInInspector] public float lifeTime = 1f;                           // How long the ability lives without hitting anything
    [HideInInspector] public List<Ability> abilities = new List<Ability> { }; // All the Ability Scripts a player can use

    private GameObject clonedParticle;

    public void AddAbility(Ability newAbility)
    {
        if (abilities.Count == abilityCount)
        {
            print("In this if block");
            return;
        }

        abilities.Insert(0, newAbility);
        abilities.Add(newAbility);
    }

    public void TriggerAbility(int abilityIndex)
    {
        StartCoroutine(CastAbility(abilityIndex));
    }

    IEnumerator CastAbility(int abilityIndex)
    {
        print("We see cast ability being called");
        Culmination(abilityIndex);
        yield return new WaitForSeconds(culminationTime);
        Launch();
        yield return new WaitForSeconds(lifeTime);
        Release();
    }

    // This represents the ability being charged up
    private void Culmination(int abilityIndex)
    {
        //Instantiate a copy of our projectile and store it in a new GameObject variable called clonedParticle
        clonedParticle = Instantiate(abilities[abilityIndex].aParticles, spawn.position, transform.rotation) as GameObject;
    }

    // This represents the ability being launched.
    private void Launch()
    {
        //Add force to the instantiated bullet, pushing it forward away from the spawn location, using projectile force for how hard to push it away
        clonedParticle.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * particleForce);
    }

    // This represents the death of the ability
    private void Release()
    {
        Destroy(clonedParticle);
    }
}
