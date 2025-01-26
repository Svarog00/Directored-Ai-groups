using InteractableGroupsAi;
using InteractableGroupsAi.Agents;

public class HasTargetCondition : AgentCondition
{
    private IAgentState _characterState;

    public HasTargetCondition(IAgentState agentContext) : base(agentContext)
    {
        _characterState = agentContext;
    }

    public override bool Check() => _characterState.CurrentTarget != null;

    public override bool CheckState(IAgentState context) => context.CurrentTarget != null;
}
