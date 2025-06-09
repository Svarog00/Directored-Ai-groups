using AiLibrary.Other;
using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using static UnityEngine.GraphicsBuffer;

public class ExchangeItemsGoal : Goal
{
    private readonly string _itemName;

    public ExchangeItemsGoal(CompositeGroupCondition condition, IGroupContext group, string itemName) : base(condition)
    {
        _itemName = itemName;

        SetGroupContext(group);
    }

    public override void Accept()
    {
        ProcessGoal();
    }

    private void ProcessGoal()
    {
        var itemsCount = Group.GetState().GetItemsCount(_itemName);
        var neededItems = itemsCount - Group.GetState().MembersCount;

        var source = GroupsHolder.GetGroup(Group.GetState().GroupId);
        var friend = GroupsHolder.GetClosestFriendlyGroup(source);

        var inItem = "Medkit";
        var outItem = "Snack";

        if (_itemName == "Snack")
        {
            inItem = "Snack";
            outItem = "Medkit";
        }

        if(neededItems < friend.GetState().GetItemsCount(_itemName))
        {
            AiLogger.Log($"EXCHANGE SUCCESS");
            AiLogger.Warning($"{inItem}, {outItem}");
            Group.GetState().Exchange(outItem, inItem, neededItems);
        }
        else
        {
            AiLogger.Error($"EXCHANGE FAIL");
        }

        GroupsHolder.DrawLine(UnityEngine.Color.green, Group.GetState(), friend.GetState());
        Group.GetNewGoal();
    }
    public override string ToString() => nameof(ExchangeItemsGoal);
}
