using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float speed = 1;

    public Track track;

    private float distance = 0;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = track.getPosition(distance);
    }

    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        updatePosition();
    }

    void updatePosition()
    {
        Vector2 targetPos = track.getPosition(distance);
        if (distance >= track.Length)
        {
            transform.position = targetPos;
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            Vector2 dir = track.getPosition(distance) - (Vector2)transform.position;
            rb2d.velocity = dir.normalized * speed;
        }
    }
}
