using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            Touch touch = Input.GetTouch(0);

            if (teleporting)
            {
                TouchRegistered(touch);
            }

            else
            {
                TouchRegistered(touch);
            }
        }
    }

    private void TouchRegistered(Touch touch)
    {
        var currentGameObject = EventSystem.current.currentSelectedGameObject;
        if (currentGameObject != null && currentGameObject.name == "TeleportAbility")
        {
            teleporting = true;
            Time.timeScale = timeSlowDown;
            Time.fixedDeltaTime = timeSlowDown;
            return;
        }


        if (touch.phase == TouchPhase.Began && teleporting == true)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = transform.position.z;
            transform.position = touchPosition;
            Time.timeScale = 1;
            Time.fixedDeltaTime = 1;
            teleporting = false;
        }

        else if (touch.phase == TouchPhase.Moved && !teleporting)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = transform.position.z;
            transform.position = touchPosition;
        }
    }
}
