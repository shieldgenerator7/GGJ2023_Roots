using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Bullet;
    public float Frequency = .5f;
    public float velocity = 100f;

    public AudioClip gunClip;

    private float nextShot = 0f;

    public Transform origin;

    private void FixedUpdate()
    {
        if (TreeTracker.Instance != null && TreeTracker.Instance.isWaveActive)
        {
            nextShot -= Time.deltaTime;
            if (nextShot <= 0f)
            {
                nextShot = Frequency;
                var bullet = Instantiate(Bullet, origin);
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocity);
                SFXContoller.instance?.PlaySFX(gunClip);
            }
        }
    }
}
