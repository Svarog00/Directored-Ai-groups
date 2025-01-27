using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;

public class InDangerConsideration : Consideration
{
    private const float DangerDistance = 15f;

    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestEnemyGroup(source);

        if (enemy == null) return 0f;

        var output = Vector3.Distance(context.CurrentPosition, enemy.GetState().CurrentPosition);

        if (output <= DangerDistance)
            return 1;

        return 0;
    }
}
