using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Track : MonoBehaviour
{
    [Tooltip("The EdgeCollider2D that will be used as the track")]
    public EdgeCollider2D ec2d;

    public float Length
    {
        get
        {
            float distance = 0;
            Vector2[] points = ec2d.points;
            for(int i = 1; i < ec2d.pointCount; i++)
            {
                distance += Vector2.Distance(points[i], points[i - 1]);
            }
            return distance;
        }
    }

    public Vector2 getPosition(float distance)
    {
        float distanceSoFar = 0;
        Vector2[] points = ec2d.points;
        for (int i = 1; i < ec2d.pointCount; i++)
        {
            Vector2 point = points[i];
            Vector2 prevPoint = points[i - 1];
            Vector2 path = point - prevPoint;
            float mag = path.magnitude;
            if (mag + distanceSoFar < distance)
            {
                distanceSoFar += mag;
            }
            else
            {
                float leftOver = distance - distanceSoFar;
                return prevPoint + (path.normalized * leftOver)
                    //remove offset
                    + (Vector2)transform.position;
            }
        }
        return Vector2.zero;
    }
}
