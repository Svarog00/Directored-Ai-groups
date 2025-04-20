using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System;
using System.Numerics;

public class CurrentLocationPointOfInterestConsideration : Consideration
{
    private const float MaxDistance = 10f;

    public override float GetScore(IGroupState context)
    {
        var point = PointsHolder.GetNearestPoint(context.CurrentPosition, context.LastPosition, true);
        var distance = Vector3.Distance(point, context.CurrentPosition);
        return Math.Clamp(distance, 0f, MaxDistance);
    }
}
