using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public float speed = 1;

    public Track track;

    private float distance = 0;

    private Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        updatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        distance += speed * Time.deltaTime;
        updatePosition();
    }

    void updatePosition()
    {
        transform.position = track.getPosition(distance);
    }
}
