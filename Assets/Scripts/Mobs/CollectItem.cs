using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int AddAmmoAmount = 1;
    public float lifeSpawn = 15f;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerShooter>().AddAmmo(AddAmmoAmount);
            SFXContoller.instance.PlaySFX(clip);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        lifeSpawn -= Time.deltaTime;
        if(lifeSpawn <= 0 )
        {
            Destroy(gameObject);
        }
    }

}
