using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC : MonoBehaviour
{
    public List<AudioClip> voiceLines;

    public Collider2D physicsColl;

    private bool collected = false;
    public bool Collected
    {
        get => collected;
        set
        {
            collected = value;
            //
            physicsColl.enabled = !collected;
            rb2d.isKinematic = collected;
        }
    }

    private Rigidbody2D rb2d;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController)
            {
                FindObjectOfType<TreeGameObject>().findPerch(this);
                randomVoiceLine();
            }
        }
    }

    public void randomVoiceLine()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = voiceLines[Random.Range(0, voiceLines.Count)];
            audioSource.Play();
        }
    }
}
