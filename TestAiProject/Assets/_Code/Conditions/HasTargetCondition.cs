using InteractableGroupsAi;

public class HasTargetCondition : AgentCondition
{
    private CharacterState _characterState;

    public HasTargetCondition(CharacterState agentContext) : base(agentContext)
    {
    }

    public override bool Check() => _characterState.CurrentTarget != null;
}
