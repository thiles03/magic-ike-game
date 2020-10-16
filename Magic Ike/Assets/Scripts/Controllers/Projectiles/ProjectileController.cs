using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    [Header("Projectile Stats")]
    public int manaCost = 10;

    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private int timeToLive = 5; //Time in seconds that projectile will exist
    [SerializeField]
    private int damage = 10;

    //Reference a casting and impact effect
    [Header("Effects")]
    [SerializeField]
    private GameObject impactEffect = null;
    [SerializeField]
    private GameObject castEffect = null;

    private void Start()
    {
        Instantiate(castEffect, transform.position, transform.rotation);
        Destroy(gameObject, timeToLive);
    }

    //Forward movement
    void Update()
    {
        transform.Translate (Vector3.forward * speed * Time.deltaTime);
    }

    //Destroy on impact and damage an enemy
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);

        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
        }
    }
}
