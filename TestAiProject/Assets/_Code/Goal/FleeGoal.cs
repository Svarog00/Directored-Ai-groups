using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

public class FleeGoal : Goal
{
    public FleeGoal(CompositeGroupCondition condition, IGroupContext group) : base(condition)
    {
        SetGroupContext(group);
    }

    public override void Accept()
    {
        var targetVector = PointsHolder.GetNearestPoint(Group.GetState().CurrentPosition);

        Group.GetState().SetTargetPosition(targetVector);
        var state = Group.GetState() as GroupState;
        foreach (var agent in state.Agents)
        {
            agent.SetTargetPosition(targetVector);
        }
    }
}
