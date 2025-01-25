using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System.Linq;
using System.Numerics;

public class CurrentLocationPointOfInterestConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        var point = PointsHolder.GetNearestPoint(context.CurrentPosition);
        var distance = Vector3.Distance(point, context.CurrentPosition);
        return distance;
    }
}
