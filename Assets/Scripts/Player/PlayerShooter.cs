using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float spawnBuffer = 1;
    public float launchSpeed = 5;

    public GameObject bulletPrefab;

    private bool bulletShot = false;

    public void processPlayerStateChanged(PlayerState playerState)
    {
        if (playerState.ability1)
        {
            if (!bulletShot)
            {
                bulletShot = true;
                spawnBullet(playerState.lookDirection);
            }
        }
        else
        {
            bulletShot = false;
        }
    }

    private void spawnBullet(Vector2 dir)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = (Vector2)transform.position + (dir.normalized * spawnBuffer);
        bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * launchSpeed;
    }
}
