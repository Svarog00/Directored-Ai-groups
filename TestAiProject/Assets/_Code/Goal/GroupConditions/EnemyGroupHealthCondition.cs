using AiLibrary.Other;
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
        var resultState = action.GetNewState();
        if (resultState == null) return 0f;

        var delta = 1 - (resultState.CurrentHealth - GroupState.CurrentHealth) / 100;
        return delta;
    }
}
