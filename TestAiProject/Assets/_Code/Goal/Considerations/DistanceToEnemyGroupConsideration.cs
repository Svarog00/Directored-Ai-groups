using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System;
using System.Numerics;

public class DistanceToEnemyGroupConsideration : Consideration
{
    private const float MaxDistance = 10f;
    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var output = Vector3.Distance(context.CurrentPosition, enemy.GetState().CurrentPosition);
        return Math.Clamp(output, 0f, MaxDistance); ;
    }
}
