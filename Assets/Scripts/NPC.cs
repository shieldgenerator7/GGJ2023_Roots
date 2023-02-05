using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC : MonoBehaviour
{
    public List<AudioClip> voiceLines;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = voiceLines[Random.Range(0, voiceLines.Count)];
                audioSource.Play();
            }
        }
    }
}
