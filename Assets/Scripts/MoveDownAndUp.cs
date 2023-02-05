using UnityEngine;

public class MoveDownAndUp : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 10f;

    private Vector3 startPosition;
    private bool movingDown = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingDown)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition - Vector3.up * distance, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, startPosition - Vector3.up * distance) < 0.1f)
            {
                movingDown = false;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingDown = true;
            }
        }
    }
}
