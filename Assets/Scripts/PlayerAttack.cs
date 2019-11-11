using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    SphereCollider attackCollider;
    float powerStat;
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = transform.GetComponent<SphereCollider>();
        powerStat = GetComponent<PlayerStats>().GetPower();
    }

    void Update()
    {
        
    }

    void Attack()
    {
        
    }

}
