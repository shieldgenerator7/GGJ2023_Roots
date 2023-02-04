using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnnounceWave : MonoBehaviour
{
    private Text text;

    public bool fading;
    public float startAlpha;
    public float endAlpha;
    public float fadeIn = 1f;
    public float fadeOut = 3f;


    private float currentTime = 0f;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (fading)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, currentTime / fadeIn);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            Debug.Log($"Fading: {fading} Alpha: {alpha}");

            if (text.color.a == endAlpha)
            {
                fading = false;
                currentTime = 0f;
            }
        }

        if(!fading && text.color.a != startAlpha)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(endAlpha, startAlpha, currentTime / fadeOut);
            
            Debug.Log($"Fading: {fading} Alpha: {alpha}");
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);


        }
    }

    public void SetText(string value)
    {
        text.text = value;
        currentTime = 0f;
        fading = true;
    }
}
