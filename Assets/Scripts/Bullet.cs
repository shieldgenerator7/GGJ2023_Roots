using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 1f;

    private void FixedUpdate()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "mob":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Player":
            case "tree":
            case "bullet":
                //do nothing
                break;
            default:
                Destroy(gameObject);
                break;
        }

    }

}
