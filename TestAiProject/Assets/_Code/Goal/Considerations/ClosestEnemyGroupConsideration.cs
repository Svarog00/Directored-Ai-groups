using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public class ClosestEnemyGroupConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        if (source == null)
            return 0f;

        var enemy = GroupsHolder.GetClosestEnemyGroup(source);
        if (enemy == null)
        {
            return 0f;
        }

        return RelationsHolder.GetRelations(context.GroupId, enemy.GroupId);
    }
}