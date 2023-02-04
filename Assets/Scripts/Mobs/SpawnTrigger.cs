using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public Wave wave;
    public MobSpawner mobSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tree")
        {
            mobSpawner.QueueWave(wave);
            gameObject.SetActive(false);
        }
    }

}
