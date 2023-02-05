using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float spawnBuffer = 1;
    public float launchSpeed = 5;


    public float maxAmmo = 50f;
    public int startingAmmo = 25;
    private float _ammo = 25f;

    public float ammo
    {
        set {
            _ammo = value;
            if(_ammo > maxAmmo)
                _ammo = maxAmmo;
            if(_ammo < 0 ) 
                _ammo = 0;
        } 
    }

    public GameObject bulletPrefab;

    private bool bulletShot = false;

    private void Awake()
    {
        ammo = startingAmmo;
    }

    public void processPlayerStateChanged(PlayerState playerState)
    {
        if (playerState.ability1)
        {
            if (!bulletShot)
            {
                if (_ammo > 0f)
                {
                    bulletShot = true;
                    spawnBullet(playerState.lookDirection);
                    _ammo -= 1f;
                }
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

    public void AddAmmo(int amount)
    {
        ammo = _ammo + amount;
    }

    public float GetAmmoPercent() {
        return _ammo / maxAmmo;
    }
}
