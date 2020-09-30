using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Header("Projectile Stats")]
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private int timeToLive = 5;
    [SerializeField]
    private int damage = 10;

    public int manaCost = 10;

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

    void Update()
    {
        transform.Translate (Vector3.forward * speed * Time.deltaTime);
    }

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
