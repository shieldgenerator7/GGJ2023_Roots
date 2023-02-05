using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Bullet;
    public float Frequency = .5f;

    private float nextShot = 0f;

    private void FixedUpdate()
    {
        if (TreeTracker.Instance != null && TreeTracker.Instance.isWaveActive)
        {
            nextShot -= Time.deltaTime;
            if (nextShot <= 0f)
            {
                nextShot = Frequency;
                var bullet = Instantiate(Bullet, transform);
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
            }
        }
    }
}
