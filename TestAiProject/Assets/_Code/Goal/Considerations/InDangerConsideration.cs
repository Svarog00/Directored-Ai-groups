using AiLibrary.Other;
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
        return output <= DangerDistance ? 1 : 0;
    }
}

public class NotInDangerConsideration : Consideration
{
    private const float DangerDistance = 10f;

    public override float GetScore(IGroupState context)
    {
        var source = GroupsHolder.GetGroup(context.GroupId);
        var enemy = GroupsHolder.GetClosestFriendlyGroup(source);

        if (enemy == null) return 0f;

        var output = Vector3.Distance(context.CurrentPosition, enemy.GetState().CurrentPosition);

        return output <= DangerDistance ? 0 : 1;
    }
}

public class NeedItemConsideration : Consideration
{
    private readonly string _itemName;

    public NeedItemConsideration(string itemName)
    {
        _itemName = itemName;
    }

    public override float GetScore(IGroupState context)
    {
        var foodCount = context.GetItemsCount(_itemName);
        return 1 - foodCount / context.MembersCount;
    }
}
