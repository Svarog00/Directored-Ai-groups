using InteractableGroupsAi;
using InteractableGroupsAi.Director.Groups;
using System.Numerics;

public class LocationGroupCondition : GroupCondition
{
    public LocationGroupCondition(IGroupState groupContext) : base(groupContext)
    {
    }

    public override bool Check()
    {
        return GroupState.CurrentPosition == new System.Numerics.Vector3(1, 1, 1);
    }

    public override float GetConditionDelta(AgentAction action)
    {
        var newState = action.GetNewState();
        return 1 - Vector3.Distance(newState.CurrentPosition, GroupState.CurrentPosition);
    }
}
