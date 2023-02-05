using System.Collections;
using UnityEngine;

public class GlowFade : MonoBehaviour
{
    public float glowSpeed = 1f;
    public float fadeSpeed = 0.5f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;

    private Light glow;
    private float targetIntensity;
    private float currentIntensity;

    void Start()
    {
        glow = GetComponent<Light>();
        targetIntensity = maxIntensity;
    }

    void Update()
    {
        currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, glowSpeed * Time.deltaTime);
        glow.intensity = currentIntensity;

        if (glow.intensity == maxIntensity)
        {
            targetIntensity = minIntensity;
        }
        else if (glow.intensity == minIntensity)
        {
            targetIntensity = maxIntensity;
        }
    }
}
