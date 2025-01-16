using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director.Goals;
using System.Numerics;

public class MoveToLocationGoal : Goal
{
    private readonly Vector3 _locationPosition;

    public MoveToLocationGoal(CompositeGroupCondition condition) : base(condition)
    {

    }

    public override void Accept()
    {

    }
}
