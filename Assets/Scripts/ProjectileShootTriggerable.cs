using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour
{

    [HideInInspector] public GameObject particle;                            // GameObject variable to hold a reference to our Partcile system prefab
    public Transform spawn;                            // Transform variable to hold the location where we will spawn our projectile
    [HideInInspector] public float particleForce = 250f;                    // Float variable to hold the amount of force which we will apply to launch our projectiles
    [HideInInspector] public float culminationTime = 1f;
    [HideInInspector] public float lifeTime = 1f;

    private GameObject clonedParticle;

    public void TriggerAbility()
    {
        StartCoroutine(CastAbility());
    }

    private IEnumerator CastAbility()
    {
        Culmination();
        yield return new WaitForSeconds(culminationTime);
        Launch();
        yield return new WaitForSeconds(lifeTime);
        Release();
    }

    // This represents the ability being charged up
    private void Culmination()
    {
        //Instantiate a copy of our projectile and store it in a new rigidbody variable called clonedPartcle
        print("Particle name is " + particle.name);
        clonedParticle = Instantiate(particle, spawn.position, transform.rotation) as GameObject;
    }

    // This represents the ability being launched.
    private void Launch()
    {
        //Add force to the instantiated bullet, pushing it forward away from the pawn location, using projectile force for how hard to push it away
        clonedParticle.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * particleForce);
    }

    // This represents the death of the ability
    private void Release()
    {
        Destroy(clonedParticle);
    }
}
