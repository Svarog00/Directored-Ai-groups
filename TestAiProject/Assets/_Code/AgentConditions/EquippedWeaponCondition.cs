using InteractableGroupsAi;
using InteractableGroupsAi.Agents;

public class EquippedWeaponCondition : AgentCondition
{
    private IAgentState _characterState;

    public EquippedWeaponCondition(IAgentState characterState) : base(characterState) 
    {
        _characterState = characterState;
    }

    public override bool Check()
    {
        return _characterState.CurrentHand is Weapon;
    }

    public override bool CheckState(IAgentState context) => context.CurrentHand is Weapon;
}
