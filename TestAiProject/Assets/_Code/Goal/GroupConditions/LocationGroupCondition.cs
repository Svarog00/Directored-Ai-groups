using InteractableGroupsAi;
using InteractableGroupsAi.Director.Groups;

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
        return 1f;
    }
}
