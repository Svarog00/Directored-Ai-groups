using InteractableGroupsAi;
using InteractableGroupsAi.Agents;

public class EquippedItemCondition : AgentCondition
{
    private CharacterState _characterState;
    private string _name;

    public EquippedItemCondition(CharacterState agentContext, string itemName) : base(agentContext)
    {
        _characterState = agentContext;
        _name = itemName;
    }

    public override bool Check() => _characterState.CurrentHand.Name.Equals(_name);

    public override bool CheckState(IAgentState context) => context.CurrentHand.Name.Equals(_name);
}