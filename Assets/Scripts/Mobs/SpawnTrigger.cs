using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public Wave wave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tree")
        {
            MobSpawner.instance.QueueWave(wave);
            Destroy(gameObject);
        }
    }

}
