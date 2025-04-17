using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;

public class InDangerConsideration : Consideration
{
    private const float DangerDistance = 5f;

    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var output = Vector3.Distance(context.CurrentPosition, enemy.GetState().CurrentPosition);

        return output <= DangerDistance ? 1 : 0;
    }
}
public class NotInDangerConsideration : Consideration
{
    private const float DangerDistance = 5f;

    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var output = Vector3.Distance(context.CurrentPosition, enemy.GetState().CurrentPosition);

        return output <= DangerDistance ? 0 : 1;
    }
}
