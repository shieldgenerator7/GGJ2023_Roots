using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject deathEffect;
    public int strength;

    private void Awake()
    {
        TreeTracker.Instance.RegisterMob(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (TreeTracker.Instance != null)
        {
            if (transform.position.x < TreeTracker.Instance.TreeLocation.position.x)
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
            }
            else
            {
                rb.velocity = new Vector3(speed * -1, 0f, 0f);
            }
        }
        else
        {
            rb.velocity = new Vector3(speed * -1, 0f, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tree")
        {
            collision.gameObject.GetComponent<TreeGameObject>().Damage(strength);
            KillMe();
            
        }
    }

    private void OnDestroy()
    {
        TreeTracker.Instance.DeregisterMob(gameObject);
    }

    public void KillMe()
    {
        //spawn effect
        if (deathEffect != null)
        {
            var splat = Instantiate(deathEffect, gameObject.transform.parent);
            splat.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

}
