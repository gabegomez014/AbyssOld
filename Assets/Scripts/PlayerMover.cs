using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    private const float EPSILON = 0.2f;

    [SerializeField]
    private float timeSlowDown = 0.1f;      // The point where time gets slowed down to
    private bool teleporting = false;       // True when player hits the teleport button, false otherwise
    Rigidbody rb;

    [HideInInspector] public float speed = 5f;         // This is how fast a character moves. This will be replaced by character stat once the stats system gets implemented

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

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
            TouchRegistered(touch);
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

        else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved && !teleporting)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = transform.position.z;

            if (System.Math.Abs(transform.position.x - touchPosition.x) > EPSILON)
            {
                print(System.Math.Abs(transform.position.x - touchPosition.x));
                var direction = transform.position.x - touchPosition.x;         // If positive, move to the lef. If negative, move to the right

                if (direction > 0)
                {
                    rb.velocity = new Vector3(-speed,0,0);          // Move Left
                }

                else if (direction < 0)
                {
                    rb.velocity = new Vector3(speed, 0, 0);         // Move Right
                }
                
            }
        }

        else if (touch.phase == TouchPhase.Ended)
        {
            rb.velocity = new Vector3(0,0,0);               // Stop movements when the finger is lifted
        }
    }
}
