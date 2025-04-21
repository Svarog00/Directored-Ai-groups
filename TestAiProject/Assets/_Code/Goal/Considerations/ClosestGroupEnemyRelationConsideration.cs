using AiLibrary.Other;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;
using UnityEngine;

public class ClosestGroupEnemyRelationConsideration : Consideration
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

        var relation = RelationsHolder.GetRelations(context.GroupId, enemy.GroupId);
        var output = (float)relation / (float)RelationsHolder.LowestRelations;
        AiLogger.Log($"#Enemy {output}");
        return output;
    }
}
public class ClosestGroupRelationConsideration : Consideration
{
    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        if (source == null)
            return 0f;

        var enemy = GroupsHolder.GetClosestFriendlyGroup(source);
        if (enemy == null)
        {
            return 0f;
        }

        var relation = RelationsHolder.GetRelations(context.GroupId, enemy.GroupId);
        var output = (float)relation / (float)RelationsHolder.MaxRelations;
        AiLogger.Log($"#Friend {output}");
        return output;
    }
}