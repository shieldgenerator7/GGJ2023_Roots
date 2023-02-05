using UnityEngine;

public class GhostBob : MonoBehaviour
{
    public float bobSpeed = 1f;
    public float bobAmount = 0.1f;

    private Vector3 startPosition;
    private float timer = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime * bobSpeed;
        float bob = Mathf.Sin(timer) * bobAmount;
        transform.position = startPosition + new Vector3(0f, bob, 0f);
    }
}
