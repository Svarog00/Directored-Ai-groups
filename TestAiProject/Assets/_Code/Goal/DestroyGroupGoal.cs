using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using InteractableGroupsAi.Director.Groups;

public class DestroyGroupGoal : Goal
{
    public GroupState TargetGroup => _target;

    private GroupState _target;

    public DestroyGroupGoal(CompositeGroupCondition condition) : base(condition)
    {

    }

    public override void Accept()
    {

    }
}