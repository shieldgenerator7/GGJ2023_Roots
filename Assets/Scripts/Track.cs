using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            for (int i = 1; i < ec2d.pointCount; i++)
            {
                Vector2 point = convert(points[i]);
                Vector2 prevPoint = convert(points[i - 1]);
                distance += Vector2.Distance(point, prevPoint);
            }
            return distance;
        }
    }

    public Vector2 getPosition(float distance)
    {
        //Early exit: not going far enough
        if (distance < 0)
        {
            return convert(ec2d.points.First());
        }
        //Early exit: going too far
        if (distance >= Length)
        {
            return convert(ec2d.points.Last());
        }
        //
        float distanceSoFar = 0;
        Vector2[] points = ec2d.points;
        for (int i = 1; i < ec2d.pointCount; i++)
        {
            Vector2 point = convert(points[i]);
            Vector2 prevPoint = convert(points[i - 1]);
            Vector2 path = point - prevPoint;
            float mag = path.magnitude;
            if (mag + distanceSoFar < distance)
            {
                distanceSoFar += mag;
            }
            else
            {
                float leftOver = distance - distanceSoFar;
                return prevPoint + (path.normalized * leftOver);
            }
        }
        return Vector2.zero;
    }

    private Vector2 convert(Vector2 edgePos) => transform.TransformPoint(edgePos);

}
