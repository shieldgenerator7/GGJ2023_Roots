using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeController : MonoBehaviour
{
    public float speed = 1;
    public float slowPercent = 0.1f;
    public float enemySearchRadius = 10;

    public Track track;

    private float distance = 0;

    private Rigidbody2D rb2d;
    private bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = track.getPosition(distance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var movespeed = speed;
        if (TreeTracker.Instance?.isWaveActive ?? false)
        {
            bool slow = false;
            RaycastHit2D[] rch2ds = Physics2D.CircleCastAll(transform.position, enemySearchRadius, Vector2.right, 0);
            if (rch2ds.Any(rch2d => rch2d.collider.GetComponent<Enemy>()))
            {
                slow = true;
            }

            if (slow)
            {
                movespeed = speed * slowPercent;
            }
        }
        distance += movespeed * Time.deltaTime;
        updatePosition(movespeed);
    }

    void updatePosition(float speed)
    {
        Vector2 targetPos = track.getPosition(distance);
        if (distance >= track.Length)
        {
            transform.position = targetPos;
            rb2d.velocity = Vector2.zero;
            if (!complete)
            {
                complete = true;
                onCompleted?.Invoke();
            }
        }
        else
        {
            Vector2 dir = track.getPosition(distance) - (Vector2)transform.position;
            rb2d.velocity = dir.normalized * speed;
        }
    }
    public delegate void OnCompleted();
    public event OnCompleted onCompleted;
}
