using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2023-02-03: copied from CharacterRigTest.Utility
public static class Utility 
{
    #region Vector3 Extension Methods
    public static Vector3 setX(this Vector3 v, float x)
        => new Vector3(x, v.y, v.z);
    public static Vector3 setY(this Vector3 v, float y)
        => new Vector3(v.x, y, v.z);
    public static Vector3 setZ(this Vector3 v, float z)
        => new Vector3(v.x, v.y, z);
    #endregion

    public static Plane raycastPlane = new Plane(Vector3.forward, Vector3.zero);
    public static Vector2 ScreenToWorldPoint(Vector3 screenPoint)
    {
        //2019-01-28: copied from an answer by Tomer-Barkan: https://answers.unity.com/questions/566519/camerascreentoworldpoint-in-perspective.html
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        float distance;
        raycastPlane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
