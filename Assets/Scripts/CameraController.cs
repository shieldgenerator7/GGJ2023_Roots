using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform follow;
    public LayerMask groundLayerMask;
    public float minOrthoSize = 1;
    public float maxOrthoSize = 7;
    public float minDistance = 0;
    public float maxDistance = 10;
    public float groundDetectOffset = 1;

    private float prevY = float.MinValue;
    private float curY = 0;
    private float prevDistance = 0;

    private Vector3 offset;
    private ContactFilter2D filter;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - follow.position;
        filter = new ContactFilter2D();
        filter.layerMask = groundLayerMask;
        cam = GetComponent<Camera>();
    }
    private void Awake()
    {
        prevDistance = getDistance();
        prevY = curY;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //zoom in zoom out
        float distance = getDistance();//updates curY as well
        //
        float percent = getPercent(distance);
        if (prevY != curY)
        {
            float prevPercent = getPercent(prevDistance);
            percent = Mathf.Lerp(prevPercent, percent, Time.deltaTime);
            prevY =  Mathf.Lerp(prevY, curY, Time.deltaTime);
            prevDistance = Mathf.Lerp(prevDistance, distance, Time.deltaTime);
        }
        else {
            prevDistance = distance;
            prevY = curY;
        }
        float ortho = (maxOrthoSize - minOrthoSize) * percent + minOrthoSize;
        cam.orthographicSize = ortho;

        //position
        Vector3 percentOffset = (offset * percent);
        percentOffset.z = offset.z;
        transform.position = follow.position + percentOffset;
    }

    float getDistance()
    {
        //get distance to ground
        RaycastHit2D[] results;
        results = new RaycastHit2D[10];
        int count = Physics2D.Raycast(
            (Vector2)follow.position + (Vector2.down * groundDetectOffset),
            Vector2.down,
            filter,
            results
            );
        float distance = float.MaxValue;
        for (int i = 0; i < count; i++)
        {
            RaycastHit2D rch2d = results[i];
            if (rch2d && !rch2d.collider.isTrigger)
            {
                float dist = Vector2.Distance(follow.position, rch2d.point);
                if (dist < distance)
                {
                    distance = dist;
                    curY = rch2d.point.y;
                }
            }
        }
        return distance;
    }

    float getPercent(float distance)
    {
        return (distance - minDistance) / (maxDistance - minDistance);
    }
}
