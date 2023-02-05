using System.Collections;
using UnityEngine;

public class rooter : MonoBehaviour
{
    public float growthSpeed = 0.01f;
    public float maxSize = 9f;

    void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += new Vector3(growthSpeed, growthSpeed, growthSpeed);
        }
    }
}

