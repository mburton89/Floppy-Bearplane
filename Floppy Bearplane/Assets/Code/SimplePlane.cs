﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlane : MonoBehaviour
{
    public enum PlaneType
    {
        enemyPlane,
        allyPlane
    }

    public PlaneType activePlaneType;

    public Rigidbody2D rigidBody2D;
    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;
    public AudioSource hitSound;
    public AudioSource fireProjectileSound;
    public GameObject thrustParticlePrefab;
    public Transform particleSpawnPoint;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;
    public bool canFly;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;
    [HideInInspector] public bool canShoot;
    [HideInInspector] public Vector3 directionToFly;

    public void Init(bool isFacingRight)
    {
        if (isFacingRight)
        {
            directionToFly = Vector3.right;
        }
        else
        {
            directionToFly = Vector3.left;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
        currentArmor = maxArmor;
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Explode();
        }
    }

    private void Update()
    {
        if (canFly)
        {
            Thrust();
        }
    }

    void FixedUpdate()
    {
        if (rigidBody2D.velocity.magnitude > maxSpeed)
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        rigidBody2D.AddForce(directionToFly * acceleration); //Add force in the direction we're facing
        currentSpeed = maxSpeed; //Set our speed to our max speed
        float randomX = Random.Range(-0.1f, 0.1f);
        float randomY = Random.Range(-0.1f, 0.1f);
        Vector3 spawnPosition = new Vector3(particleSpawnPoint.position.x + randomX, particleSpawnPoint.position.y + randomY);
        Instantiate(thrustParticlePrefab, spawnPosition, transform.rotation);
    }

    public void FireProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation) as Projectile;
        Instantiate(thrustParticlePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.rigidBody2D.AddForce(transform.up * projectileSpeed);
        projectile.Init(this.gameObject);
        fireProjectileSound.Play();
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());
    }

    private IEnumerator FireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void TakeDamage(int damageToTake)
    {
        currentArmor -= damageToTake;
        hitSound.Play();
        if (currentArmor <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(Resources.Load("ShipExplosion"), transform.position, transform.rotation);
        ScreenShaker.Instance.ShakeScreen();
        Destroy(gameObject);
    }
}
