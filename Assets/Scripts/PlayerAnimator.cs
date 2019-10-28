using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    const float movementSmoothTime = 0.1f;

    private const float EPSILON = 0.2f;

    Animator animator;
    Rigidbody rb;
    PlayerController pc;                // Need this to get the speed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = rb.velocity.x;

        if (moveDirection < 0)
        {
            moveDirection = 0;
        }

        else if (System.Math.Abs(moveDirection) < EPSILON)
        {
            moveDirection = 0.5f;
        }

        else if (moveDirection > 0)
        {
            moveDirection = 1;
        }
        animator.SetFloat("movementPercent", moveDirection, movementSmoothTime, Time.deltaTime);

    }
}
