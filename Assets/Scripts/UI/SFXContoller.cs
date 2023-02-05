using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]  
public class SFXContoller : MonoBehaviour
{
    private AudioSource sfx;

    private SFXContoller instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance ==  null) {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        sfx = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
