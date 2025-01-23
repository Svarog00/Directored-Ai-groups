using InteractableGroupsAi;
using InteractableGroupsAi.Director.Groups;

public class EnemyGroupHealthCondition : GroupCondition
{
    public EnemyGroupHealthCondition(IGroupState desiredState) : base(desiredState) 
    {
        
    }

    public override bool Check() { return true; }

    public override float GetConditionDelta(AgentAction action)
    {
        var newStateHealth = action.GetNewState().CurrentHealth;
        var delta = GroupState.MaxHealth - newStateHealth;
        var newGroupHealth = GroupState.CurrentHealth - delta;

        return newGroupHealth / GroupState.MaxHealth;
    }
}
