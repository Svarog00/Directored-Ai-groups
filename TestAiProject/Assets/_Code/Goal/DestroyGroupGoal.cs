using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

public class DestroyGroupGoal : Goal
{
    public GroupState TargetGroup => _target;

    private GroupState _target;

    public DestroyGroupGoal(CompositeCondition condition) : base(condition)
    {

    }

    public void SetTargetGroup(GroupState groupContext)
    {
        _target = groupContext;
    }
}