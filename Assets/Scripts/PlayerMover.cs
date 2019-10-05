using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private float nextReadyTime;
    private float cooldownTimeLeft;
    private float cooldownDuration = 2;

    // Update is called once per frame
    void Update()
    {

        MoveReady();

    }

    public void MoveReady()
    {
        if (Time.time > nextReadyTime)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchRegistered(touch);
            }
        }

        else
        {
            Cooldown();
        }
    }

    private void TouchRegistered(Touch touch)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.y = 0;
        transform.position = touchPosition;


    }

    private void Cooldown()
    {
        cooldownTimeLeft -= Time.deltaTime;
    }
}
