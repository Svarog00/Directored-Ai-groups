using AiLibrary.Other;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public static class PointsHolder
{
    private static List<Vector3> _points = new List<Vector3>();

    public static IEnumerable<Vector3> Points => _points;

    public static void Add(Vector3 point) => _points.Add(point);

    public static Vector3 GetNearestPoint(Vector3 position)
    {
        float min = float.MaxValue;
        Vector3 closestPoint = PointsHolder.Points.First();
        foreach (var point in PointsHolder.Points)
        {
            var distance = Vector3.Distance(position, point);
            if (distance < min)
            {
                min = distance;
                closestPoint = point;
            }
        }

        return closestPoint;
    }
}
