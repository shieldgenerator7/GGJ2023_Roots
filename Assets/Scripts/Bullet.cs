using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 1f;

    private void FixedUpdate()
    {
        lifeSpan -= Time.fixedDeltaTime;
        if (lifeSpan <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "mob":
                collision.gameObject.GetComponent<Enemy>().KillMe();
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
