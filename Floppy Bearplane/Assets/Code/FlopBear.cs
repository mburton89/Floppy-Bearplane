using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlopBear : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float turnSpeed;
    public GameObject rocket;

    [SerializeField] private KeyCode _thrust;
    [SerializeField] private KeyCode _turnLeft;
    [SerializeField] private KeyCode _turnRight;

    private Rigidbody2D _rigidBody2D;

    [SerializeField] ThrustParticleSpawner _thrustParticleSpawner;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(_thrust))
        {
            Thrust();
        }
        else if (Input.GetKeyUp(_thrust))
        {
            _thrustParticleSpawner.canSpawnParticles = false;
        }

        if (Input.GetKey(_turnLeft))
        {
            TurnLeft();
        }
        else if (Input.GetKey(_turnRight))
        {
            TurnRight();
        }
    }

    void FixedUpdate()
    {
        if (_rigidBody2D.velocity.magnitude > maxSpeed)
        {
            _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * maxSpeed;
        }
    }

    void Thrust()
    {
        _rigidBody2D.AddRelativeForce(rocket.transform.up * acceleration * Time.deltaTime);
        _thrustParticleSpawner.canSpawnParticles = true;
    }

    void TurnLeft()
    {
        rocket.transform.Rotate(0, 0, turnSpeed * Time.deltaTime, Space.Self);
    }

    void TurnRight()
    {
        rocket.transform.Rotate(0, 0, -turnSpeed * Time.deltaTime, Space.Self);
    }
}
