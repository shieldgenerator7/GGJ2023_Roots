using System.Collections;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    public float flickerSpeed = 1f;
    public float flickerAmount = 0.1f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;

    private Light candleLight;
    private float targetIntensity;
    private float currentIntensity;

    void Start()
    {
        candleLight = GetComponent<Light>();
        targetIntensity = maxIntensity;
        currentIntensity = maxIntensity;
    }

    void Update()
    {
        currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, flickerSpeed * Time.deltaTime);
        candleLight.intensity = currentIntensity;

        if (Mathf.Abs(candleLight.intensity - targetIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
