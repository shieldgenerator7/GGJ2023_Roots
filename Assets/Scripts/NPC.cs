using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<AudioClip> voiceLines;
    public Turret turret;

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
            if (turret)
            {
                turret.gameObject.SetActive(collected);
            }
        }
    }

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        voiceLines.RemoveAll(line => !line);
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
        AudioClip clip = voiceLines[Random.Range(0, voiceLines.Count)];
        if (SFXContoller.instance)
        {
            SFXContoller.instance.PlaySFX(clip);
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
