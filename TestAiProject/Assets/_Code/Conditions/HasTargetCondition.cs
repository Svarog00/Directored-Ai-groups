using InteractableGroupsAi;
using InteractableGroupsAi.Agents;

public class HasTargetCondition : AgentCondition
{
    private CharacterState _characterState;

    public HasTargetCondition(CharacterState agentContext) : base(agentContext)
    {
        _characterState = agentContext;
    }

    public override bool Check() => _characterState.CurrentTarget != null;
}
