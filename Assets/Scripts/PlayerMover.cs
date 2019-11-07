using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    private const float EPSILON = 0.1f;

    [SerializeField]
    private GameObject teleportActivatedGO; // GameObject for teleport activation particle effects
    private ParticleSystem teleportPS;      // Particle systems for teleport activation
    private GameObject clone;

    [SerializeField]
    private float timeSlowDown = 0.1f;      // The point where time gets slowed down to
    private bool teleporting = false;       // True when player hits the teleport button, false otherwise

    [SerializeField]
    private float cooldownDuration;
    private float nextReadyTime;
    private float cooldownTimeLeft;

    Rigidbody rb;
    SkinnedMeshRenderer playerTexture;
    float moveStat;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveStat = GetComponent<PlayerStats>().GetSpeed();
        teleportPS = teleportActivatedGO.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveReady();

    }


    public void MoveReady()
    {
        if (cooldownTimeLeft > 0)
        {
            cooldownTimeLeft -= Time.deltaTime;
        }

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
            if (clone == null && cooldownTimeLeft <= 0)
            {
                clone = Instantiate(teleportActivatedGO);
                teleporting = true;
                Time.timeScale = timeSlowDown;
                var main = clone.gameObject.GetComponent<ParticleSystem>().main;
                main.simulationSpeed = 1 / timeSlowDown;
                return;
            }
        }


        if (touch.phase == TouchPhase.Began && teleporting == true)
        {
            Destroy(clone);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = transform.position.z;
            transform.position = touchPosition;
            Time.timeScale = 1;
            teleporting = false;
            cooldownTimeLeft = cooldownDuration;
        }

        else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved && !teleporting)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0;
            touchPosition.z = transform.position.z;

            if (System.Math.Abs(transform.position.x - touchPosition.x) > EPSILON)
            {
                var direction = transform.position.x - touchPosition.x;         // If positive, move to the lef. If negative, move to the right

                if (direction < 0.3 && direction > -0.3)
                {
                    rb.velocity = new Vector3(0, 0, 0);             // Checking for the in-between in order to force stop movement
                }

                if (direction > 1)
                {
                    rb.velocity = new Vector3(-moveStat,0,0);          // Move Left
                }

                else if (direction < -1)
                {
                    rb.velocity = new Vector3(moveStat, 0, 0);         // Move Right
                }
                
            }
        }

        else if (touch.phase == TouchPhase.Ended)
        {
            rb.velocity = new Vector3(0,0,0);               // Stop movements when the finger is lifted
        }
    }
}
