﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public int damageToGive;
    GameObject firingShip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SimplePlane>() && collision.gameObject != firingShip)
        {
            collision.GetComponent<SimplePlane>().TakeDamage(damageToGive);
            Destroy(gameObject);
        }
    }

    public void Init(GameObject firer)
    {
        firingShip = firer;
    }
}
