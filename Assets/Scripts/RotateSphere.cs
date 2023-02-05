using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public float rotationSpeed = 10.0f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

