using InteractableGroupsAi.Agents.Conditions;
using InteractableGroupsAi.Director;
using InteractableGroupsAi.Director.Groups;

public static class GoalHolder
{
    public static MoveToLocationGoal MoveToLocation()
    {
        var moveToCondition = new CompositeGroupCondition();
        var desiredState = new DesiredGroupState();
        desiredState.CurrentPosition = new System.Numerics.Vector3(1, 1, 1);

        moveToCondition.AddCondition(new LocationGroupCondition(desiredState));

        return new MoveToLocationGoal(moveToCondition);
    }

    public static GroupScorer GoalScorer(IGroupState model) => new GroupScorer(model);
}