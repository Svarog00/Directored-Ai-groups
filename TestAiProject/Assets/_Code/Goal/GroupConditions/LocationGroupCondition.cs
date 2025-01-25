using AiLibrary.Other;
using InteractableGroupsAi;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;

public class LocationGroupCondition : GroupCondition
{
    public LocationGroupCondition(IGroupState desiredState) : base(desiredState)
    {
    }

    public override bool Check()
    {
        return true;
    }

    public override float GetConditionDelta(AgentAction action)
    {
        var newState = action.GetNewState();
        var delta = Vector3.Distance(newState.CurrentPosition, GroupState.TargetPosition);

        return delta;
    }
}
