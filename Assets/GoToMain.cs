using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMain : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var audio = GetComponent<AudioSource>();
        if (!audio.isPlaying) {
            GetComponent<SceneChange>().MainMenuScene();
        }
    }
}
