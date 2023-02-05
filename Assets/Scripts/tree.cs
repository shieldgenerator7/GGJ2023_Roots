using System.Collections;
using UnityEngine;

public class tree : MonoBehaviour
{
    public float growthSpeed = 0.01f;
    public float maxSize = 2f;

    void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += new Vector3(growthSpeed, growthSpeed, growthSpeed);
        }
    }
}
