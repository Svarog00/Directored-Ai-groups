using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

public class ExchangeItemsGoal : Goal
{
    public ExchangeItemsGoal(CompositeGroupCondition condition, IGroupContext group) : base(condition)
    {
        SetGroupContext(group);
    }

    public override void Accept()
    {
        ProcessGoal();
    }

    private void ProcessGoal()
    {
        var group = GroupsHolder.GetClosestGroup(Group);

        var state = Group.GetState() as GroupState;

        Group.GetNewGoal();
    }
}
