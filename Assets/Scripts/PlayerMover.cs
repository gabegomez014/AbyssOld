using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float timeSlowDown = 0.1f;      // The point where time gets slowed down to
    private bool teleporting = false;       // True when player hits the teleport button, false otherwise

    // Update is called once per frame
    void Update()
    {

        MoveReady();

    }

    public void MoveReady()
    {
        if (Input.touchCount > 0)
        {
            print("Teleporting is " + teleporting);
            Touch touch = Input.GetTouch(0);

            if (teleporting)
            {
                print("In teleporting");
                TouchRegistered(touch);
                Time.timeScale = 1;
            }

            else
            {
                TouchRegistered(touch);
            }
        }
    }

    public void Teleport()
    {
        teleporting = true;
        Time.timeScale = timeSlowDown;
    }

    private void TouchRegistered(Touch touch)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.y = 0;
        touchPosition.z = transform.position.z;
        transform.position = touchPosition;
    }
}
