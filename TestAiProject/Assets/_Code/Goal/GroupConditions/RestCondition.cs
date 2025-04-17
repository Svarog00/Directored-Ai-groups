using AiLibrary.Other;
using InteractableGroupsAi;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;

public class RestCondition : GroupCondition
{
    public RestCondition(IGroupState desiredState) : base(desiredState)
    {
    }

    public override bool Check()
    {
        return true;
    }

    public override float GetConditionDelta(AgentAction action)
    {
        var newState = action.GetNewState();
        if (newState == null) return 0f;
        var delta = GroupState.CurrentRest - newState.CurrentRest;

        AiLogger.Log($"#Location {delta}");
        return delta;
    }
}
