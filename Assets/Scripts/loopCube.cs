using System.Collections;
using UnityEngine;

public class loopCube: MonoBehaviour
{
    public float speed = 10f;
    public float radius = 5f;

    private float angle;

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }
}

