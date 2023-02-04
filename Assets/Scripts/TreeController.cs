using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float speed = 1;

    public int redirectLayerId = 0;

    private Vector2 direction = Vector2.right;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.velocity.magnitude < speed)
        {
            rb2d.velocity += direction * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == redirectLayerId)
        {
            direction = Vector2.up;
        }
    }
}
